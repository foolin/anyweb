using System;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Sockets;
using System.Collections;

namespace Studio.Net
{
    public class FtpAgent
    {
        Socket ftp;
        byte[] buffer = new byte[512];
        //bool logined, debug;
        int retValue;
        Encoding ASCII = Encoding.ASCII;
        string reply;
        string  mes;
        int bytes;
        static int __queueID = 0;
        int timeout = 10;
        public event FtpActionCompleted ActionCompleted;
        public event FtpSucc ActionSucc;
        public event FtpErr ActionErr;
        public event FtpBeginAction ActionBegin;

        private string _server;
        /// <summary>
        /// Server
        /// </summary>
        public string Server
        {
            get { return _server; }
            set { _server = value; }
        }

        private string _username;
        /// <summary>
        /// UserName
        /// </summary>
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;
        /// <summary>
        /// Password
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private int _port;
        /// <summary>
        /// Port
        /// </summary>
        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }

        private string _remotePath;

        public string RemotePath
        {
            get { return _remotePath; }
            set { _remotePath = value; }
        }


        public FtpAgent(string server, int port, string username, string password, string remotePath)
        {
            this.Server = server;
            this.Port = port;
            this.UserName = username;
            this.Password = password;
            this.RemotePath = remotePath;
        }

        public FtpAgent()
        {
        }        

        #region getFileList
        /**/
        /// <summary>
        /// Return a string array containing the remote directory's file list.
        /// </summary>
        /// <param name="mask"></param>
        /// <returns></returns>
        public string[] GetFileList(string mask)
        {
            Socket cSocket = createDataSocket();
            FtpResult list = Do(FtpAction.ListFiles, mask, 150, 125);

            string s = "";

            while (true)
            {

                int bytes = cSocket.Receive(buffer, buffer.Length, 0);
                s += ASCII.GetString(buffer, 0, bytes);

                if (bytes < buffer.Length)
                {
                    break;
                }
            }

            string[] ss = s.Split('\n');

            cSocket.Close();

            readReply();

            if (retValue != 226)
            {
                throw new IOException(reply.Substring(4));
            }
            return ss;
        }
        #endregion

        #region getFileSize
        /**/
        /// <summary>
        /// Return the size of a file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public long GetFileSize(string fileName)
        {
            FtpResult getSize = Do(FtpAction.GetFileSize, fileName, 213);
            if (getSize.Success)
            {
                return long.Parse(getSize.ResultMessage);
            }
            else
            {
                return (long)0;
            }
        }
        #endregion

        #region login
        /**/
        /// <summary>
        /// Login to the remote server.
        /// </summary>
        public void Login()
        {
            ftp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(Dns.GetHostEntry(this.Server).AddressList[0], this.Port);
            if (this.ActionBegin != null)
            {
                this.ActionBegin("Starting connect server:" + this.Server);
            }

            try
            {
                ftp.Connect(ep);
            }
            catch
            {
                Fail("Connect to server " + this.Server + "failed!");
                return;
            }

            readReply();
            if (retValue != 220)
            {
                Close();
                return;
            }

            FtpResult setUser = Do(FtpAction.SetUser, this.UserName, 331, 230);

            if (setUser.ResultCode == 331)
            {
                FtpResult setPass = Do(FtpAction.SetPassword, this.Password, 230, 202);
            }
            //logined = true;
            Succ("Connected to " + this.Server);
            ChDir(this.RemotePath);
        }
        #endregion

        void Succ(string msg)
        {
            if (this.ActionSucc != null)
                this.ActionSucc(msg);
        }

        void Fail(FtpResult result)
        {
            if (this.ActionErr != null)
                this.ActionErr(result.ResultMessage);

            this.cleanup();
        }
        void Fail(string err)
        {
            if (this.ActionErr != null)
                this.ActionErr(err);
        }
        #region setBinaryMode

        /**/
        /// <summary>
        /// If the value of mode is true, set binary mode for downloads.
        /// Else, set Ascii mode.
        /// </summary>
        /// <param name="mode"></param>
        private void SetBinaryMode(bool mode)
        {
            if (mode)
            {
                Do(FtpAction.SetMode, "I", 200);
            }
            else
            {
                Do(FtpAction.SetMode, "A", 200);
            }
        }
        #endregion

        #region Download
        /**/
        /// <summary>
        /// Download a file to the Assembly's local directory,
        /// keeping the same file name.
        /// </summary>
        /// <param name="remFileName"></param>
        /// <returns></returns>
        public bool Download(string remFileName)
        {
            return Download(remFileName, "", false);
        }

        /**/
        /// <summary>
        /// Download a remote file to the Assembly's local directory,
        /// keeping the same file name, and set the resume flag.
        /// </summary>
        /// <param name="remFileName"></param>
        /// <param name="resume"></param>
        /// <returns></returns>
        public bool Download(string remFileName, Boolean resume)
        {
            return Download(remFileName, "", resume);
        }

        /**/
        /// <summary>
        /// Download a remote file to a local file name which can include
        /// a path. The local file name will be created or overwritten,
        /// but the path must exist.
        /// </summary>
        /// <param name="remFileName"></param>
        /// <param name="locFileName"></param>
        /// <returns></returns>
        public bool Download(string remFileName, string locFileName)
        {
            return Download(remFileName, locFileName, false);
        }



        /**/
        /// <summary>
        /// Download a remote file to a local file name which can include
        /// a path, and set the resume flag. The local file name will be
        /// created or overwritten, but the path must exist.
        /// </summary>
        /// <param name="remFileName"></param>
        /// <param name="locFileName"></param>
        /// <param name="resume"></param>
        /// <returns></returns>
        public bool Download(string remFileName, string locFileName, Boolean resume)
        {

            bool Finish = false;
            bool FileExists = false;

            SetBinaryMode(true);
            try
            {
                FileInfo fileInfo = new FileInfo(locFileName);
                if (fileInfo.Exists)
                {
                    fileInfo.IsReadOnly = false;
                    fileInfo.Delete();
                }
            }
            catch
            {
                return false;
            }
            foreach (string str in GetFileList("."))
            {
                if (str.IndexOf(remFileName.ToUpper(), StringComparison.CurrentCultureIgnoreCase) != -1)
                {
                    FileExists = true;
                    break;
                }
            }
            if (!FileExists)
            {
                //Console.WriteLine("文件不存在!");
                return false;
            }
            Console.WriteLine("Downloading file " + remFileName + " from " + this.Server + "/" + this.RemotePath);

            if (locFileName.Equals(""))
            {
                locFileName = remFileName;
            }

            if (!File.Exists(locFileName))
            {
                Stream st = File.Create(locFileName);
                st.Close();
            }
            FileStream output = null;
            try
            {
                output = new FileStream(locFileName, FileMode.Open);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            Socket cSocket = createDataSocket();
            long offset = 0;
            if (resume)
            {
                offset = output.Length;
                if (offset > 0)
                {
                    sendCommand("REST " + offset);
                    if (retValue != 350)
                    {
                        //throw new IOException(reply.Substring(4));
                        //Some servers may not support resuming.
                        Finish = false;
                        offset = 0;
                    }
                }

                if (offset > 0)
                {
                    //if (debug)
                    //{
                    //    Console.WriteLine("seeking to " + offset);
                    //}
                    long npos = output.Seek(offset, SeekOrigin.Begin);
                    Console.WriteLine("new pos=" + npos);
                }
            }

            sendCommand("RETR " + remFileName);
            if (!(retValue == 150 || retValue == 125))
            {
                throw new IOException(reply.Substring(4));
            }

            while (true)
            {
                bytes = cSocket.Receive(buffer, buffer.Length, 0);
                output.Write(buffer, 0, bytes);
                if (bytes <= 0)
                {
                    Finish = true;
                    break;
                }
            }

            output.Close();
            if (cSocket.Connected)
            {
                cSocket.Close();
            }
            readReply();
            if (!(retValue == 226 || retValue == 250))
            {
                throw new IOException(reply.Substring(4));
            }
            return Finish;
        }
        #endregion

        public bool IsDirExists(string dirName)
        {
            FtpResult result = Do(FtpAction.ChangePath, dirName, 250);
            this.ChDir(this.RemotePath);//保持当前目录位置
            return result.Success;
        }

        #region Upload

        public void UploadFolder(string path)
        {
            ArrayList queues = CreateQueues(path, path, RemotePath);
            int idx = 0, total = queues.Count, folders = 0, files = 0;
            DateTime start = DateTime.Now;
            foreach (FtpQueue q in queues)
            {
                if (q.IsFolder)
                {
                    folders ++;
                    this.MkDir(q.RemotePath);
                    this.ChDir(q.RemoteFolder);
                }
                else
                {
                    files ++;
                    this.UploadFile(q.LocalPath, q.RemoteFolder);
                }
                System.Threading.Thread.Sleep(timeout);
                Succ(string.Format("Upload {0} of {1} successfully!", ++idx, total));
            }
            TimeSpan ts = DateTime.Now - start;
            string time = string.Format("{0} hours {1} minutes {2} seconds.", ts.TotalHours, ts.TotalMinutes - ts.TotalHours * 60, ts.TotalSeconds - ts.TotalMinutes * 60);
            Succ(string.Format("Upload {0} folders and {1} files sucessfully.takes {2}", folders, files, time));
        }

        ArrayList CreateQueues(string localFolder, string localRoot, string remoteRoot)
        {
            ArrayList queues = new ArrayList();
            DirectoryInfo dir = new DirectoryInfo(localFolder);
            if (dir.Exists == false)
            {
                return queues;
            }
            FtpQueue q = new FtpQueue();
            q.ID = ++__queueID;
            q.IsFolder = true;
            q.LocalPath = localFolder;
            q.RemotePath = remoteRoot + localFolder.Substring(localRoot.Length).Replace("\\", "/");
            q.RemoteFolder = q.RemotePath;
            queues.Add(q);
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                q = new FtpQueue();
                q.ID = ++__queueID;
                q.IsFolder = false;
                q.LocalPath = file.FullName;
                q.RemotePath = remoteRoot + file.FullName.Substring(localRoot.Length).Replace("\\", "/");
                q.RemoteFolder = remoteRoot + file.DirectoryName.Substring(localRoot.Length).Replace("\\", "/");
                queues.Add(q);
            }
            DirectoryInfo[] subs = dir.GetDirectories();
            foreach (DirectoryInfo sub in subs)
            {
                queues.AddRange(CreateQueues(sub.FullName, localRoot, remoteRoot));
            }
            return queues;
        }

        /**/
        /// <summary>
        /// Upload a file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Upload a file is success!</returns>
        public bool UploadFile(string fileName)
        {
            return Upload(fileName, false);
        }

        public bool UploadFile(string fileName, string toFolder)
        {
            if (RemotePath != toFolder)
            {
                this.ChDir(toFolder);
            }
            return Upload(fileName, false);
        }

        /**/
        /// <summary>
        /// Upload a file and set the resume flag.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="resume"></param>
        /// <returns></returns>
        public bool Upload(string fileName, Boolean resume)
        {
            Socket cSocket = createDataSocket();
            long offset = 0;
            if (resume)
            {
                try
                {
                    SetBinaryMode(true);
                    offset = GetFileSize(fileName);
                }
                catch
                {
                    offset = 0;
                }
            }

            if (offset > 0)
            {
                FtpResult setRest = Do(FtpAction.SetREST, offset.ToString(), 350);
                sendCommand("REST " + offset);
                if (setRest.Success == false)
                {
                    offset = 0;
                }
            }

            FtpResult setStor = Do(FtpAction.SetSTOR, Path.GetFileName(fileName), 125, 150);

            if (setStor.Success == false)
            {
                return false;
            }
            // open input stream to read source file
            FileStream input = new FileStream(fileName, FileMode.Open);
            if (offset != 0)
            {
                input.Seek(offset, SeekOrigin.Begin);
            }
            int bytes;
            while ((bytes = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                cSocket.Send(buffer, bytes, 0);
            }
            input.Close();
            if (cSocket.Connected)
            {
                cSocket.Close();
            }
            readReply();
            if (!(retValue == 226 || retValue == 250))
            {
                throw new IOException(reply.Substring(4));
            }
            Succ("Upload file successfully!" + fileName);
            return true;
        }
        #endregion

        #region DeleteRemoteFile
        /**/
        /// <summary>
        /// Delete a file from the remote FTP server.
        /// </summary>
        /// <param name="fileName"></param>
        public void DeleteRemoteFile(string fileName)
        {
            sendCommand("DELE " + fileName);
            if (retValue != 250)
            {
                throw new IOException(reply.Substring(4));
            }

        }

        public void DeleteRemoteFolder(string path)
        {
            string currentPath = this.RemotePath;
            this.ChDir(path);
            string[] files = this.GetFileList("");
            foreach (string file in files)
            {
                if (file != "" && file.IndexOf('.') > 0)
                {
                    DeleteRemoteFile(file);
                }
            }
            this.ChDir(currentPath);
            try
            {
                this.RmDir(path);//尝试删除目录，忽略非空情况
            }
            catch { }
        }
        #endregion

        #region RenameRemoteFile
        /**/
        /// <summary>
        /// Rename a file on the remote FTP server.
        /// </summary>
        /// <param name="oldFileName"></param>
        /// <param name="newFileName"></param>
        public void RenameRemoteFile(string oldFileName, string newFileName)
        {
            sendCommand("RNFR " + oldFileName);

            if (retValue != 350)
            {
                throw new IOException(reply.Substring(4));
            }

            //  known problem
            //  rnto will not take care of existing file.
            //  i.e. It will overwrite if newFileName exist
            sendCommand("RNTO " + newFileName);
            if (retValue != 250)
            {
                throw new IOException(reply.Substring(4));
            }

        }
        #endregion

        #region MkDir
        /**/
        /// <summary>
        /// Create a directory on the remote FTP server.
        /// </summary>
        /// <param name="dirName"></param>
        public bool MkDir(string dirName)
        {
            return MkDir(dirName, false);
        }

        public bool MkDir(string dirName, bool createTree)
        {
            if (createTree == true && dirName.LastIndexOf('/') > 0) //创建目录结构
            {
                this.ChDir("/");
                string[] dirs = dirName.Substring(1).Split('/');
                string path = "";
                for (int i = 0; i < dirs.Length - 1; i++)
                {
                    path += '/' + dirs[i];
                    this.MkDir(path, false);
                    this.ChDir(path);
                }
            }
            FtpResult result = Do(FtpAction.MakeFolder, dirName, 257);
            return result.Success;
        }
        #endregion

        #region RmDir
        /**/
        /// <summary>
        /// Delete a directory on the remote FTP server
        /// </summary>
        /// <param name="dirName"></param>
        public void RmDir(string dirName)
        {
            sendCommand("RMD " + dirName);

            if (retValue != 250)
            {
                throw new IOException(reply.Substring(4));
            }

        }
        #endregion

        #region ChDir
        /**/
        /// <summary>
        /// Change the current working directory on the remote FTP server.
        /// </summary>
        /// <param name="dirName"></param>
        public void ChDir(string dirName)
        {
            if (dirName.Equals("."))
            {
                return;
            }

            FtpResult result = Do(FtpAction.ChangePath, dirName, 250);
            if (result.Success)
            {
                this.RemotePath = dirName;

                Succ("Current directory is " + RemotePath);
            }
        }
        #endregion

        #region Close()
        /**/
        /// <summary>
        ///  Close the FTP connection.
        /// </summary>
        public void Close()
        {
            if (ftp != null)
            {
                sendCommand("QUIT");
            }

            cleanup();
            Console.WriteLine("Closing");
        }
        #endregion

        #region OTHER

        private void readReply()
        {
            mes = "";
            reply = readLine();
            retValue = Int32.Parse(reply.Substring(0, 3));
        }

        private void cleanup()
        {
            if (ftp != null)
            {
                ftp.Close();
                ftp = null;
            }
            //logined = false;
        }
        #endregion

        #region readLine
        private string readLine()
        {
            while (true)
            {
                bytes = ftp.Receive(buffer, buffer.Length, 0);
                mes += ASCII.GetString(buffer, 0, bytes);
                if (bytes < buffer.Length)
                {
                    break;
                }
            }

            char[] seperator = { '\n' };
            string[] mess = mes.Split(seperator);

            if (mes.Length > 2)
            {
                mes = mess[mess.Length - 2];
            }
            else
            {
                mes = mess[0];
            }

            if (!mes.Substring(3, 1).Equals(" "))
            {
                return readLine();
            }

            //if (debug)
            //{
            //    for (int k = 0; k < mess.Length - 1; k++)
            //    {
            //        Console.WriteLine(mess[k]);
            //    }
            //}
            return mes;
        }
        #endregion

        private FtpResult Do(FtpAction action, string args, params int[] succCodes)
        {
            FtpResult result = new FtpResult();
            result.CommandType = action;
            string cmd = "";
            switch (action)
            {
                case FtpAction.ListFiles:
                    {
                        cmd = "NLST";
                        break;
                    }
                case FtpAction.SetUser:
                    {
                        cmd = "USER";
                        break;
                    }
                case FtpAction.SetPassword:
                    {
                        cmd = "PASS";
                        break;
                    }
                case FtpAction.ChangePath:
                    {
                        cmd = "CWD";
                        break;
                    }
                case FtpAction.SetPASV:
                    {
                        cmd = "PASV";
                        break;
                    }
                case FtpAction.GetFileSize:
                    {
                        cmd = "SIZE";
                        break;
                    }
                case FtpAction.SetREST:
                    {
                        cmd = "REST";
                        break;
                    }
                case FtpAction.SetSTOR:
                    {
                        cmd = "STOR";
                        break;
                    }
                case FtpAction.MakeFolder:
                    {
                        cmd = "MKD";
                        break;
                    }
            }
            if (args != "")
            {
                cmd += " " + args;
            }

            result.CommandString = cmd;
            if (this.ActionBegin != null)
            {
                this.ActionBegin(cmd);
            }

            Byte[] cmdBytes = Encoding.ASCII.GetBytes((cmd + "\r\n").ToCharArray());
            ftp.Send(cmdBytes, cmdBytes.Length, 0);
            mes = "";
            reply = readLine();
            result.ResultCode = Int32.Parse(reply.Substring(0, 3));
            result.ResultMessage = reply.Substring(4);
            foreach (int succCode in succCodes)
            {
                if (succCode == result.ResultCode)
                {
                    result.Success = true;
                    break;
                }
            }
            if (this.ActionCompleted != null)
            {
                this.ActionCompleted(result);
            }
            return result;
        }

        #region sendCommand
        private void sendCommand(String command)
        {
            Byte[] cmdBytes = Encoding.ASCII.GetBytes((command + "\r\n").ToCharArray());
            ftp.Send(cmdBytes, cmdBytes.Length, 0);
            readReply();
        }
        #endregion

        #region createDataSocket
        private Socket createDataSocket()
        {
            FtpResult setPasv = Do(FtpAction.SetPASV, "", 227);

            int index1 = setPasv.ResultMessage.IndexOf('(');
            int index2 = setPasv.ResultMessage.IndexOf(')');
            string ipData = setPasv.ResultMessage.Substring(index1 + 1, index2 - index1 - 1);
            int[] parts = new int[6];
            int len = ipData.Length;
            int partCount = 0;
            string buf = "";
            for (int i = 0; i < len && partCount <= 6; i++)
            {

                char ch = Char.Parse(ipData.Substring(i, 1));
                if (Char.IsDigit(ch))
                    buf += ch;
                else if (ch != ',')
                {
                    throw new IOException("Malformed PASV reply: " + reply);
                }

                if (ch == ',' || i + 1 == len)
                {

                    try
                    {
                        parts[partCount++] = Int32.Parse(buf);
                        buf = "";
                    }
                    catch (Exception)
                    {
                        throw new IOException("Malformed PASV reply: " + setPasv.ResultMessage);
                    }
                }
            }
            string ipAddress = parts[0] + "." + parts[1] + "." + parts[2] + "." + parts[3];
            int port = (parts[4] << 8) + parts[5];
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(Dns.GetHostEntry(ipAddress).AddressList[0], port);
            try
            {
                s.Connect(ep);
            }
            catch (Exception)
            {
                throw new IOException("Can't connect to remote server");
            }
            return s;
        }
        #endregion

    }    

    public class FtpResult
    {
        public FtpResult() { }

        private bool _succ;

        public bool Success
        {
            get { return _succ; }
            set { _succ = value; }
        }

        private FtpAction _cmdType;

        public FtpAction CommandType
        {
            get { return _cmdType; }
            set { _cmdType = value; }
        }

        private string _cmdString;

        public string CommandString
        {
            get { return _cmdString; }
            set { _cmdString = value; }
        }

        private string _resultMsg;

        public string ResultMessage
        {
            get { return _resultMsg; }
            set { _resultMsg = value; }
        }

        private int _resultCode;

        public int ResultCode
        {
            get { return _resultCode; }
            set { _resultCode = value; }
        }
    }

    public class FtpQueue
    {
        public FtpQueue()
        {

        }

        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private bool _isFolder;

        public bool IsFolder
        {
            get { return _isFolder; }
            set { _isFolder = value; }
        }

        private string _remoteFolder;

        public string RemoteFolder
        {
            get { return _remoteFolder; }
            set { _remoteFolder = value; }
        }


        private string _localPath;

        public string LocalPath
        {
            get { return _localPath; }
            set { _localPath = value; }
        }

        private string _remotePath;

        public string RemotePath
        {
            get { return _remotePath; }
            set { _remotePath = value; }
        }
    }

    public enum FtpAction
    { 
        SetUser,
        SetPassword,
        SetMode,
        ChangePath,
        SetPASV,
        SetREST,
        SetSTOR,
        ListFiles,
        GetFileSize,
        UploadFile,
        DeleteFile,
        MakeFolder,
        DeleteFolder,
        RenameFile,
        RenameFolder
    }
    public delegate void FtpBeginAction(string cmd);
    public delegate void FtpActionCompleted(FtpResult result);
    public delegate void FtpSucc(string msg);
    public delegate void FtpErr(string msg);
}