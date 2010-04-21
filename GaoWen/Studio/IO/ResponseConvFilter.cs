using System; 
using System.Text; 
using System.Text.RegularExpressions; 
using System.IO; 
using System.Web; 

namespace Studio.IO
{ 

	/// <summary>
	/// Response¹ýÂËÆ÷
	/// ÊµÏÖ¼òÌåÖÐÎÄÏò·±ÌåÖÐÎÄ×ª»»
	/// Earth
	/// </summary>
	public class ResponseConvFilter : Stream 
	{ 
		private Stream _sink; 
		private long _position; 

		public ResponseConvFilter(Stream sink) 
		{ 
			_sink = sink; 
		} 

		public override bool CanRead 
		{ 
			get 
			{ 
				return true; 
			} 
		} 

		public override bool CanSeek 
		{ 
			get 
			{ 
				return true; 
			} 
		} 

		public override bool CanWrite 
		{ 
			get 
			{ 
				return true; 
			} 
		} 

		public override long Length 
		{ 
			get 
			{ 
				return 0; 
			} 
		} 

		public override long Position 
		{ 
			get 
			{ 
				return _position; 
			} 
			set 
			{ 
				_position = value; 
			} 
		} 

		public override long Seek(long offset, System.IO.SeekOrigin direction) 
		{ 
			return _sink.Seek(offset, direction); 
		} 

		public override void SetLength(long length) 
		{ 
			_sink.SetLength(length); 
		} 

		public override void Close() 
		{ 
			_sink.Close(); 
		} 

		public override void Flush() 
		{ 
			_sink.Flush(); 
		} 

		public override int Read(byte[] buffer, int offset, int count) 
		{ 
			return _sink.Read(buffer, offset, count); 
		} 

		private const string _sGB=@"°¨°ª°­°®°À°Â°Ó°Õ°Ú°Ü°ä°ì°í°ï°ó°÷°ù°þ±¥±¦±¨±«±²±´±µ±·±¸±¹±Á±Ê±Ï±Ð±Ò±Õ±ß±à±á±ä±ç±è±ê±î±ð±ñ±ô±õ±ö±÷±ý²¢²¦²§²¬²µ²·²¹²Æ²Î²Ï²Ð²Ñ²Ò²Ó²Ô²Õ²Ö²×²Þ²à²á²â²ã²ï²ó²ô²õ²ö²÷²ø²ù²ú²û²ü³¡³¢³¤³¥³¦³§³©³®³µ³¹³¾³Â³Ä³Å³Æ³Í³Ï³Ò³Õ³Ù³Û³Ü³Ý³ã³å³æ³è³ë³ì³ï³ñ³ó³÷³ø³ú³û´¡´¢´¥´¦´«´¯´³´´´¸´¿´Â´Ç´Ê´Í´Ï´Ð´Ñ´Ó´Ô´Õ´Ú´Ü´í´ï´ø´ûµ£µ¥µ¦µ§µ¨µ¬µ®µ¯µ±µ²µ³µ´µµµ·µºµ»µ¼µÁµÆµËµÐµÓµÝµÞµßµãµæµçµíµöµ÷µýµþ¶¤¶¥¶§¶©¶ª¶«¶¯¶°¶³¶·¶¿¶À¶Á¶Ä¶Æ¶Í¶Ï¶Ð¶Ò¶Ó¶Ô¶Ö¶Ù¶Û¶á¶é¶ì¶î¶ï¶ñ¶ö¶ù¶û¶ü·¡·¢·£·§·©·¯·°·³·¶···¹·Ã·Ä·É·Ì·Ï·Ñ·×·Ø·Ü·ß·à·á·ã·æ·ç·è·ë·ì·í·ï·ô·ø¸§¸¨¸³¸´¸º¸¼¸¾¸¿¸Ã¸Æ¸Ç¸É¸Ï¸Ñ¸Ó¸Ô¸Õ¸Ö¸Ù¸Ú¸ä¸é¸ë¸ó¸õ¸ö¸ø¹¨¹¬¹®¹±¹³¹µ¹¹¹º¹»¹Æ¹Ë¹Ð¹Ò¹Ø¹Û¹Ý¹ß¹á¹ã¹æ¹è¹é¹ê¹ë¹ì¹î¹ñ¹ó¹ô¹õ¹ö¹ø¹ú¹ýº§º«ºººÅºÒº×ºØºáºäºèºìºóºø»¤»¦»§»©»ª»­»®»°»³»µ»¶»·»¹»º»»»½»¾»À»Á»Æ»Ñ»Ó»Ô»Ù»ß»à»á»â»ã»ä»å»æ»ç»ë»ï»ñ»õ»ö»÷»ú»ý¼¢¼£¼¥¼¦¼¨¼©¼«¼­¼¶¼·¼¸¼»¼Á¼Ã¼Æ¼Ç¼Ê¼Ì¼Í¼Ð¼Ô¼Õ¼Ö¼Ø¼Û¼Ý¼ß¼à¼á¼ã¼ä¼è¼ê¼ë¼ì¼î¼ï¼ð¼ñ¼ò¼ó¼õ¼ö¼÷¼ø¼ù¼ú¼û¼ü½¢½£½¤½¥½¦½§½«½¬½¯½°½±½²½´½º½½½¾½¿½Á½Â½Ã½Ä½Å½È½É½Ê½Î½Ï½×½Ú½Ü½à½á½ë½ì½ô½õ½ö½÷½ø½ú½ý¾¡¾¢¾£¾¥¾¨¾ª¾­¾±¾²¾µ¾¶¾·¾º¾»¾À¾Ç¾É¾Ô¾Ù¾Ý¾â¾å¾ç¾é¾î¾õ¾ö¾÷¾ø¾û¾ü¿¥¿ª¿­¿Å¿Ç¿Î¿Ñ¿Ò¿Ù¿â¿ã¿ä¿é¿ë¿í¿ó¿õ¿ö¿÷¿ù¿úÀ¡À£À©À«À¯À°À³À´ÀµÀ¶À¸À¹ÀºÀ»À¼À½À¾À¿ÀÀÀÁÀÂÀÃÀÄÀÌÀÍÀÔÀÖÀØÀÝÀàÀáÀéÀëÀïÀðÀñÀöÀ÷ÀøÀùÀúÁ¤Á¥Á©ÁªÁ«Á¬Á­Á¯Á°Á±Á²Á³Á´ÁµÁ¶Á·Á¸Á¹Á½Á¾ÁÂÁÆÁÉÁÍÁÔÁÙÁÚÁÛÁÝÁÞÁäÁåÁèÁéÁëÁìÁóÁõÁúÁûÁüÁýÂ¢Â£Â¤Â¥Â¦Â§Â¨Â«Â¬Â­Â®Â¯"
			+"Â°Â±Â²Â³Â¸Â»Â¼Â½Â¿ÂÀÂÁÂÂÂÅÂÆÂÇÂËÂÌÂÍÂÎÂÏÂÐÂÒÂÕÂÖÂ×ÂØÂÙÂÚÂÛÂÜÂÞÂßÂàÂáÂâÂæÂçÂèÂêÂëÂìÂíÂîÂðÂòÂóÂôÂõÂöÂ÷ÂøÂùÂúÃ¡Ã¨ÃªÃ­Ã³Ã´Ã¹Ã»Ã¾ÃÅÃÆÃÇÃÌÃÎÃÕÃÖÃÙÃÝÃàÃåÃíÃðÃõÃöÃùÃúÃýÄ±Ä¶ÄÆÄÉÄÑÄÓÄÔÄÕÄÖÄÙÄÚÄâÄåÄìÄíÄðÄñÄôÄöÄ÷ÄøÄûÄüÄþÅ¡Å¢Å¥Å¦Å§Å¨Å©Å±ÅµÅ·Å¸Å¹Å»Å½ÅÌÅÓÅ×ÅâÅçÅôÆ­Æ®ÆµÆ¶Æ»Æ¾ÆÀÆÃÆÄÆËÆÌÆÓÆ×ÆÜÆàÆêÆëÆïÆñÆôÆøÆúÆýÇ£Ç¤Ç¦Ç¨Ç©Ç«Ç®Ç¯Ç±Ç³Ç´ÇµÇ¹ÇºÇ½Ç¾Ç¿ÇÀÇÂÇÅÇÇÇÈÇÌÇÏÇÔÇÕÇ×ÇÞÇáÇâÇãÇêÇëÇìÇíÇîÇ÷ÇøÇûÇýÈ£È§È¨È°È´ÈµÈ·ÈÃÈÄÈÅÈÆÈÈÈÍÈÏÈÒÈÙÈÞÈíÈñÈòÈóÈ÷ÈøÈúÈüÈþÉ¡É¥É§É¨É¬É±É´É¸É¹É¾ÉÁÉÂÉÄÉÉÉËÉÍÉÕÉÜÉÞÉãÉåÉèÉðÉóÉôÉöÉøÉùÉþÊ¤Ê¥Ê¦Ê¨ÊªÊ«Ê¬Ê±Ê´ÊµÊ¶Ê»ÊÆÊÊÊÍÊÎÊÓÊÔÊÙÊÞÊàÊäÊéÊêÊôÊõÊ÷ÊúÊýË§Ë«Ë­Ë°Ë³ËµË¶Ë¸Ë¿ËÇËÊËËËÌËÏËÐËÓËÕËßËàËäËæËçËêËïËðËñËõËöËøÌ¡Ì¢Ì¬Ì¯Ì°Ì±Ì²Ì³Ì·Ì¸Ì¾ÌÀÌÌÌÎÌÐÌÖÌÚÌÜÌàÌâÌåÌëÌõÌùÌúÌüÌýÌþÍ­Í³Í·ÍºÍ¼Í¿ÍÅÍÇÍÉÍÑÍÒÍÔÍÕÍÖÍÝÍàÍäÍåÍçÍòÍøÎ¤Î¥Î§ÎªÎ«Î¬Î­Î°Î±Î³Î½ÎÀÎÂÎÅÎÆÎÈÎÊÎÍÎÎÎÏÎÐÎÑÎÔÎØÎÙÎÚÎÛÎÜÎÞÎßÎâÎëÎíÎñÎóÎýÎþÏ®Ï°Ï³Ï·Ï¸ÏºÏ½Ï¿ÏÀÏÁÏÃÏÅÏÊÏËÏÌÏÍÏÎÏÐÏÔÏÕÏÖÏ×ÏØÏÚÏÛÏÜÏßÏáÏâÏçÏêÏìÏîÏôÏùÏúÏþÐ¥Ð«Ð­Ð®Ð¯Ð²Ð³Ð´ÐºÐ»Ð¿ÐÆÐËÐÚÐâÐåÐéÐêÐëÐíÐðÐ÷ÐøÐùÐüÑ¡Ñ¢Ñ¤Ñ§Ñ«Ñ¯Ñ°Ñ±ÑµÑ¶Ñ·Ñ¹Ñ»Ñ¼ÑÆÑÇÑÈÑËÑÌÑÎÑÏÑÕÑÖÑÞÑáÑâÑåÑèÑéÑìÑîÑïÑñÑôÑ÷ÑøÑùÑþÒ¡Ò¢Ò£Ò¤Ò¥Ò©Ò¯Ò³ÒµÒ¶Ò½Ò¿ÒÃÒÅÒÇÒÏÒÕÒÚÒäÒåÒèÒéÒêÒëÒìÒïÒñÒõÒøÒûÒþÓ£Ó¤Ó¥Ó¦Ó§Ó¨Ó©ÓªÓ«Ó¬Ó®Ó±Ó´ÓµÓ¶Ó¸Ó»Ó½Ó¿ÓÅÓÇÓÊÓËÓÌÓÕÓßÓãÓæÓéÓëÓìÓïÓõÓùÓüÓþÔ¤Ô¦Ô§Ô¨Ô¯Ô°Ô±Ô²ÔµÔ¶Ô¸Ô¼Ô¾Ô¿ÔÀÔÁÔÃÔÄÔÆÔÇÔÈÔÉÔËÔÌÔÍÔÎÔÏÔÓÔÖÔØÔÜÔÝÔÞÔßÔàÔäÔæÔðÔñÔòÔóÔôÔùÔú"
			+"ÔýÔþÕ¡Õ¢Õ¤Õ©Õ«Õ®Õ±ÕµÕ¶Õ·Õ¸Õ»Õ½ÕÀÕÅÕÇÕÊÕËÕÍÕÔÕÝÕÞÕàÕâÕêÕëÕìÕïÕòÕóÕõÕöÕøÕùÖ¡Ö£Ö¤Ö¯Ö°Ö´Ö½Ö¿ÖÀÖÄÖÊÖÍÖÓÖÕÖÖÖ×ÖÚÖßÖáÖåÖçÖèÖíÖîÖïÖòÖõÖöÖüÖýÖþ×¤×¨×©×ª×¬×®×¯×°×±×³×´×¶×¸×¹×º×»×Å×Ç×È×Ê×Õ×Ù×Û×Ü×Ý×Þ×ç×é×êØ¨ØÂØÄØÇØÉØÌØÍØÐØÑØÓØÙØÛØÜØñØöØ÷ØùÙ­Ù¯Ù±Ù²Ù³Ù¶ÙÇÙÌÙÍÙÎÙÏÙÐÙÝÙáÙäÙæÙìÙðÙòÙôÙõÙ÷Ú£Ú¦Ú§Ú¨Ú©ÚªÚ«Ú¬Ú­Ú®Ú¯Ú±Ú²Ú³Ú´ÚµÚ¶Ú·Ú¸Ú¹ÚºÚ»Ú¼Ú½Ú¾Ú¿ÚÀÚÁÚÂÚÃÚÄÚÅÚÆÚÇÚÈÚÉÚÊÚËÚÌÚÍÚÎÚÏÚÐÚÑÚÒÚÓÚÔÚÕÚÖÚ×ÚØÚÙÚÚÚÛÚÜÚÝÚÞÚßÚáÚêÚíÚ÷ÚùÚþÛ£Û¦Û©ÛªÛ»Û¼Û½ÛÏÛÑÛÛÛÞÛäÛëÛîÛõÛöÛ÷Ü¼ÜÂÜÈÜÉÜÊÜÑÜ×ÜàÜãÜäÜéÜêÜñÜöÜùÜýÜþÝ£Ý¥Ý¦ÝªÝ«Ý°ÝµÝºÝÓÝÛÝÞÝäÝëÝñÝ÷ÝüÝþÞ­Þ´ÞºÞÆÞÏÞÑÞÒÞØÞâÞèÞìÞóÞüß¢ß£ß¥ß´ß¼ß½ß¿ßÂßÌßÕßØßÙßÜßàßâßæßéßëßïßõßùà¶à·à¿àÈàÎàÓàààðàøàüàýàþá«á­á°á»á½á¿áÀáÁáÉáÎáÐáÛáâáîáöáøáýâ¤â¨â¼â½â¾â¿âÀâÁâÂâÃâÄâÅâÆâÈâÉâÊâËâÍâÐâÙâÞâãâäâæâéâêâëâøâúâûâüâýã¢ã¥ã«ã³ã´ãÁãÅãÆãÇãÈãÉãÊãËãÌãÍãÎãÏãÐãÑãÓãÔãÕãÖã×ãØãÙãÚãÛãããíãñãòãøãþä¤ä¥ä«ä¯ä°ä±äµä¶äÂäÅäÉäËäÓäÙäÜäÞäääëäìäòäóäþå°å¹åÇåÉåÎåðåòåüåýæ£æ©æ«æ¬æ®æ´æµæ¿æÁæÈæÉæÍæÖæàæáæâæãæäæåæææçæèæéæêæëæìæíæîæïæðæñæòæóæôæõæöæ÷æøæúæûæüæýæþç¡ç¢ç£ç¤ç¥ç¦ç§ç¨ç©ç¬ç­ç®ç¯ç°ç±ç²ç³çµç¶ç·ç¸ç¹çºç»ç¼ç½ç¾ç¿çÀçÁçÂçÃçÄçÅçÆçÇçÈçÉçÊçËçÌçÍçÎçÏçÐçÑçÒçÓçÔçÕç×çØçÙçÚçáçâçåçççïçôçõçöè¨è¬è¯è¶è¸è¹èºè¿èÀèÇèÈèÉèÎèÐèÓèÙèÝèßèâèãèåèçèëèíèïèùèüèýé¡é¤é­é´éµé·éÄéÆéÉéÍéÖéÚéÜéÝéâéäéæéçéééëéíéîéðéñéòéóéôéöé÷éøéùéúéûéüéýéþê¡ê¢ê£ê¤ê¥ê§ê¨ê¯ê±ê¼êÊêÍêÓêÚêÛêÜêÝêÞ"
			+"êßêàêáêâêãêäêæêçêèêéêêêëêìêíêîêïë§ëªë²ëµë¹ëÊëÍëÖëÚëáëçëðë÷ì£ì©ìªì«ì¬ì­ì±ì´ìµì¾ì¿ìÀìÇìËìâìòìõìøí¡í¨íªí¯í°í³í´í¶í¸íºíÂíÃíÌíÍíÓí×íèíùíúî´î¼î¿îÅîÆîÇîÈîÉîÊîËîÌîÍîÎîÏîÑîÓîÔîÕîÖî×îØîÙîÚîÛîÜîÝîßîàîáîâîãîäîåîæîçîèîéîêîëîìîíîîîïîðîñîòîóîõî÷îøîùîúîûîüîýîþï¡ï¢ï£ï¤ï¥ï¦ï§ï¨ï©ïªï«ï¬ï®ï¯ï°ï±ï²ï¶ï·ï¸ï¹ïºï¼ï¾ï¿ïÀïÃïÄïÅïÆïÇïÈïÉïÊïËïÌïÎïÏïÒïÓïÔïÖï×ïØïÙïÚïÛïÜïÝïÞïßïàïáïâïäïæïçïèïêïëïìïíïîïðïñð£ð¯ð°ð±ð²ð³ð´ðµð¶ð·ð¸ð¹ðºð»ð¼ð½ð¾ð¿ðÀðÁðÂðÃðÄðÆðÇðÈðÉðÊðÎðÏðÐðÑðÒðÓðÔðÕðÖðØðÙðÜðÝðìðïð÷ðùñ¨ñ«ñ®ñ²ñ¼ñÀñÉñÍñÏñÐñÚñÜñßñäñïñ÷ñùñüñýñþò¡ò¢ò¤ò¥ò¦ò§ò¨ò©òªò«ò­ò°ò±ò²ò¹òºòÃòÉòÌòÍòÏòÓòåòîò÷ó¿óÆóÈóÖóÙóÝóåóæóêóìóïóñóýô¥ô¯ôµôÁôÇôÖôêôïôõõ¦õ§õºõ»õÄõÅõÈõÎõÏõÑõÒõÙõÜõæõçõéõïõòõüö£ö¦ö¨ö«ö°ö³ö´öµö¶ö·ö¸ö¹öºö»ö¼ö½ö¾öÁöÅöÇöÉöÏöÐöÑöÔöÕöÖö×öØöÚöÛöÜöÝöÞößöàöáöâöãöäöåöæöçöèöéöêöëöìöíöîöïöðöòöóöôöööøöùöúöûöü÷¡÷¢÷£÷¤÷¥÷¦÷§÷¨÷©÷¬÷­÷®÷¯÷²÷µ÷½÷Ã÷Å÷Æ÷Ê÷Ë÷Ï÷Ð÷Þ÷ò÷õ÷ú";
  
		private const string _tGB=@"°}Ì@µKÛÒ\ŠW‰ÎÁT”[”¡îCÞk½OŽÍ½‰æ^Ör„ƒï–ŒšˆóõUÝ…Øä^ªN‚ä‘v¿‡¹P®…”ÀŽÅé]ß…¾ŽÙH×ƒÞqÞp˜Ë÷M„e°TžlžIÙe”PïžK“ÜÀãKñgÊNÑaØ”…¢ÐQšˆ‘M‘K NÉnÅ“‚}œæŽú‚ÈƒÔœyŒÓÔŒ”v“½Ïsð’×‹ÀpçP®aêUîˆö‡LéLƒ”ÄcS•³ânÜ‡Ø‰mêÒr“Î·Q‘ÍÕ\òG°VßtñYuýXŸë›_ÏxŒ™® ÜP»I¾Iáh™»NäzërµAƒ¦Ó|ÌŽ‚÷¯êJ„“åN¼ƒ¾bÞoÔ~ÙnÂ”Ê[‡èÄ…²œÜf¸Zåeß_Ž§ÙJ“ú†Îà“ÛÄ‘‘„ÕQ—®”“õühÊŽ™n“vu¶\Œ§±IŸôà‡”³œìßf¾†îüc‰|ëŠÕážÕ{Õ™¯Bá”í”åVÓ†G–|„Ó—ƒöôY Ùªš×xÙ€åƒå‘”à¾„ƒ¶ê Œ¦‡îDâgŠZ‰™ùZî~ÓžºðIƒº –ðDÙE°lÁPéy¬mµ\âCŸ©¹ ØœïˆÔL¼ïwÕuUÙM¼Š‰žŠ^‘¼SØS—÷ähïL¯‚ñT¿pÖSøPÄwÝ—“áÝoÙxÑ}Ø“Ó‡‹D¿`Ô“â}ÉwŽÖÚs¶’ÚMŒù„‚ä“¾Væ€”Røéwãt‚€½oýŒmì–Ø•ã^œÏ˜‹Ù‰òÐMî™„Ž’ìêPÓ^ð^‘TØžVÒŽÎùšwý”é|Ü‰ÔŽ™™ÙF„£ÝLå‡øß^ñ”ínhÌ–éuúQÙR™MÞZø™¼táá‰Ø×oœû‘ô‡WÈA®‹„Ô’‘Ñ‰Äšg­hß€¾“Q†¾¯ˆŸ¨œoüSÖe“]Ýxš§ÙV·x•þ Z¡ÖMÕdÀLÈœ†â·«@Ø›µœ“ô™C·eð‡ÛE×Iëu¿ƒ¾ƒ˜OÝ‹¼‰”DŽ×ËE„©úÓ‹Ó›ëHÀ^¼oŠAÇvîaÙZâ›ƒrñ{šž±OˆÔ¹{égÆD¾}ÀO™z‰Aû|’þ“ìº†ƒ€œpË]™‘èbÛ`ÙvÒŠæIÅž„¦ðTužR¾Œ¢{ÊY˜ªª„ÖváuÄz²òœ‹É”‡ãq³CƒeÄ_ïœÀU½gÞIÝ^ëA¹‚Ü½YÕ]ŒÃ¾oå\ƒHÖ”ßM•x a±M„ÅÇGÇoöLó@½›îiìoçR½¯d¸‚œQ¼mŽýÅfñxÅe“þä‘Ö„¡ùN½ÓX›QÔE½^âxÜŠòEé_„Pîwš¤Õn‰¨‘©“¸ŽìÑÕF‰Kƒ~Œ’µV•ç›rÌŽh¸Qð¢”UéŸÏžÅDÈRíÙ‡Ë{™Ú”r»@ê@Ìmž‘×Ž”ˆÓ[‘ÐÀ| €žE“Æ„Ú³˜·èD‰¾îœI»hëxÑYõŽ¶Yû…–„îµ[•Ñžrë`‚zÂ“ÉßBç ‘ziºŸ”¿Ä˜æœ‘ÙŸ’¾š¼Z›öƒÉÝvÕ¯Ÿß|ç‚«CÅRà÷[„CÙUýgâœRì`ŽXîIðs„¢ýˆÃ@‡µ»\‰Å”në]˜ÇŠä“§ºtÌJ±RïB] t"
			+"“ïûuÌ”ô”ÙTµ“ä›ê‘óH…ÎäX‚HŒÒ¿|‘]žV¾GŽn”Œ\ž´y’àÝ†‚öœS¾]Õ“Ì}Á_ß‰èŒ»jò…ñ˜½j‹Œ¬”´aÎ›ñRÁR†áÙIûœÙuß~Ã}²mðzÐUMÖ™Øˆå^ãTÙQüNüq›]æVéTž‚ƒåi‰ôÖi›Ò’ƒç¾d¾’Rœç‘‘é}øQã‘Ö‡Ö\®€âc¼{ëy“ÏÄXÀô[ðHƒÈ”MÄ”f“Óá„øBÂ™ýmè‡æ‡™ŽªŸå¸”Qôâo¼~Ä“âÞr¯‘ÖZšWútšª‡Ia±Pý‹’Ùr‡Šùiò_ïhîlØšÌO‘{ÔuŠîH“ää˜ã×V—«œDÄšýRòTØM†¢šâ—‰Ó™ ¿’LãUßwºžÖtåXãQ“œ\×l‰q˜Œ†Ü ËNŠ“Œæ@˜ò†ÌƒSÂN¸[¸`šJÓHŒ‹ÝpšäƒAí•Õˆ‘c­‚¸FÚ……^Ü|òŒýxïE™à„ñ…sùo´_×Œðˆ”_À@ŸáígÕJ¼x˜s½qÜ›äJéc™ž¢Ë_öwÙÈý‚ã†Êò}’ß­š¢¼†ºY•ñ„héWê„Ù ¿˜‚ûÙpŸý½BÙd”z‘ØÔO¼Œ‹ðÄIBÂ•ÀK„ÙÂ}ŽŸª{ñÔŠŒÆ•rÎgŒ×Rñ‚„ÝßmáŒï—Ò•Ô‡‰Û«F˜ÐÝ”•øÚHŒÙÐg˜äØQ”µŽ›ëpÕl¶í˜Õf´T q½zï•Â–‘ZížÔAÕb”\ÌKÔVÃCëmëS½—šqŒO“p¹S¿s¬æi«H“é‘B”‚Ø°cž©‰¯×TÕ„šUœ« Cý½dÓ‘òvÖ`äRî}ówŒÏ—lÙNèFdÂ ŸNã~½yî^¶dˆD‰TˆFîjÍ‘Ã“ørñWñ„™E¸DÒmž³îBÈf¾Wífß`‡úžéžH¾SÈ”‚¥‚Î¾•Ö^ÐlœØÂ„¼y·€†–®Y“ëÎœu¸CÅP†èæužõ›@Õ_ŸoÊ…Ç‰]ìF„ÕÕ`åa ÞÒuÁ•ãŠ‘ò¼šÎrÝ {‚bªMB‡˜õrÀwûyÙtã•éeï@ëU¬F«I¿hðWÁw‘—¾€Žûè‚àlÔ”í‘í—Ê’‡ÌäN•Ô‡[Ï…f’¶”yÃ{ÖCŒ‘žaÖxä\á…Åd›°çnÀCÌ“‡uíšÔS”¢¾wÀmÜŽ‘Òßx°_½kŒW„ìÔƒŒ¤ñZÓ–Óßd‰ºøfø††¡†Ó éŽŸŸû}‡ÀîéØW…’³Ž©ÖVòžø„—î“P¯ƒê–°WðB˜Ó¬Ž“uˆòßb¸GÖ{ËŽ ”í“˜IÈ~átãžîUßzƒxÏË‡ƒ|‘›ÁxÔ„×hÕx×g®À[ÊaêŽãyï‹ë[™Ñ‹ëú—‘ªÀt¬“Îž IŸÉÏ‰ÚA·f†Ñ“í‚ò°bÛxÔœ¥ƒž‘nà]â™ªqÕTÝ›ô~OŠÊÅcŽZÕZ»n¶Rªz×uîAñSøxœYÞ@ˆ@†TˆA¾‰ßhîŠ¼sÜSè€Ž[»›‚é†ë…ày„òëEß\ÌNáj•žíësžÄÝd”€•ºÙÚEóvè——ØŸ“ñ„tÉÙ\Ù›¼™"
			+"„žÜˆåŽél–ÅÔpýS‚ùšÖ±K”ØÝšä—£‘ð¾`ˆqŽ¤Ù~Ã›ÚwÏUÞHæNß@Ø‘á˜‚ÉÔ\æ‚ê‡’ê± ªb ŽŽ¬à×C¿—ÂšˆÌ¼ˆ“´”SŽÃÙ|œþæR½K·NÄ[±ŠÖaÝS°™•ƒóEØiÖTÕD T²š‡ÚÙAèTºBñvŒ£´uÞDÙ˜¶ÇfÑbŠy‰Ñ îåFÙ˜‰‹¾YÕÖøáÆÙYnÛ™¾C¿‚¿vàuÔ{½MèƒÁd†Ý…‡…˜ìvÚI…Q…TÙ‘„q„¥„’‚ø‚t‚áÐƒŠƒzƒ‰ƒ°ƒ«‚Rƒf‚ôƒEƒ¯ƒ†ƒ®ƒL¼eüZ‡ÏøDƒ¼Ð–ÒCÅL·A‰VÓ“ÓÓ˜ÖŽÔnÔGÔbÔXÔgÔtÔrÕEÕCÔŸÔ‘ÔœÔ–ÔÔÕŠÕŸÔ‚ÕVÕaÕNÕOÕŒÕŽÕ†Õ˜Õ”Õ~ÕrÖRÖGÖoÖ]Ö@ÖIÖXÖOÖBÖJÕ›Öƒ×•ÖqÕžÖkÖ†×v×P×S×H×—×d×Ž„ê€êŸà—àwà’àPà”àiáBÆcŠJ„êŽ€ˆ×‰¿‰È‰Àˆº‰N‰Pˆå‰_ËGËžÇ{ÈOÉÆrÌdÊ\‰LŸ¦ÊÉœÊwËCËj ÎœîË|ÉpÈ‡ÉPÈnÉWÊ~úL¿MÊrÊ‰ÊVò‡ÌyÊšÌ`ÌAÌIË’Ì\ŠYŒÀ’Ð“»“×““¥“å”d”t”X”]”x‡\‡`‡Ò‡³†h‡“‡}‡^†ô‡‚‡ˆ‡‡‡O‡Z†î‡K‡Ê‡D‡¿‡Ë‡†Þ\‡Â‡£‡÷Ž®ŽÎŽ¾Ž½çs¹ŽFþ˜÷ˆŽV£âŽpÆ«Eªœªsª«M«Jðhï‚ðqïƒï„ï†ïðAðGðNðQðtðxð}ð~ð‚TÙs[‘Ô‘“‘Y÷í‘«‘Q‘ÃÅðÁ‘aÜ‘C‘|‘¬éVéZéébéhé`êYé‚é€ôbéé“é‹é”é’é‘é˜é êHêDêIêRž–œ¿ž{žožT›Ü›ÑœÒžgG¡œZ¬ž^ÆžcœOsž¹ž—ž]§žužtž‡žzž|ž®òqßƒÞŸßŠŒÕ†‹³‹ž‹‚Š™‹I‹ÆŒD‹z‹¹‹È‹‹‹Ü‹å‹Ô‹ßñzñ†ñ€ò|óAñwñ~ò”ò‘ñ‰óPòUòSòKò‰òsò\òˆòtò~òŠò‹ò–óKóJ¼u¼q¼v¼wÀk¼‹¼„¼‚½C½X¼›¿U½E½I½W½{½Ž½‹½¾c¾_¾p¾i¾E¾R¾^¾J¾U¾l¾~¾|¾Ÿ¾˜ÀD¾Œ¾œ¾—¿P¾‡¿N¿b¿d¿c¿r¿O¿VÀ_¿~¿z¿w¿Š¿‰Ài¿¿•À`ÀRÀQÀy­^¬|«k­‡íœ­t¬q­I­a­‹­v­‘ítíyíw˜q™À—–˜º—n™±™É™¾—d™µ™f—¿˜ï˜E˜˜å™u™è™ô™³˜ ™å˜¡™ì™Â™°™Î™‰™½™{™Á™©™´º™™_š{š‘šŒššš—š›ÜÜ—ÝVÞ_ÝTÝWÝFÞ]ÝUÝYÝeÝbÝ`ÝmÝ‚ÝyÝzÝwÝÞAÞO‘â‘ê‘ì®T•Ò•Ï•Ÿ•áÙSÙBÙLÙOÙ—"
			+"ÙDÙWÚBÙcÙlÙgÙyÙŽÒ—ÓJÒ Ó]ÓDÓMÓPÓUšÐšÚšåšè ©–VÅFÃ„Ä’ÄTáZÄeÄœšeïRïSïZï`ïjÝžýW”ÌŸ¬Ÿ˜ŸõŸî F c¶[µ¶U‘»âœ¡‘¿‘ßßeÍ´‰´X³ŒµZµa³ˆ´“´ƒ´~ý²A²€ÙÜÁ`Ábááá•á“á‘âQâAáŸå{âOâSââkâjâ[â‚â^â€âZâ•ã`â’âŽâ˜â“ãXãfãgâšèpâ‹ãCãBãGâ‰â”èIäDã™ãsäBä…äeçtèKãŸæzãäbäAçfãŒãxæ|ã“åPäCã|ç|ä@ãœç„ånäˆçHä‡ä†ä~äSäsäZäuä|åHäåQä˜åKådäŸåUåOå›å|æJåŠåšæ}æDçUçIæŸækçæyæ„æ‰è\çSçMçNæ çOæ—æ›çCç†çhç…è|ç’çjç‹èZèCèOèsæR·wøFøSødøcøù…ûRøzø|úƒøúvøŽø û[ùPûZù]ùOú‘ùYù^ùgùlù‡ù–ù˜ú_úYûWúpúwúú„úú–ú˜ûX°X°O°A°B°D¯Ž°`°a°]°d¸]¸MÒdÑžÒcÒMÒ@Òh¿‹°—ÂeÂœÂ˜í™í î@îRîMîWîhî€î…ïDî”î‹î—ïAÍAÏlÏŠÍ˜Ï–Ï Ï|ÍÏuÎ‡Ï“ÏXÏ”ÏNÀ›ºV¹a»eº`¹~ºjºD»Xº„ººˆ»f»[ÅœÆA‹–Áu¼R¿{ûŸÚŽá‰á‡ûzÜOÛ„Û•ÜVÜEÛ‹Ü]ÜQÜWÜUÜbÛ˜ÜXÜkÜgÓxÓzìnìZìVì\ýZýeý_ýfýbýlýrýpý}üwüxüƒëh×‡èŽçYôœô™õE÷|·dõV÷cõTõ^õnõb÷qõoõœ÷\õ†÷~ö–öžöˆöœõ…õõŒöaõ›öNöOöEöHöKöFöTõ õ™öl÷{öqövömüö’ööŠöŽö˜÷B÷Lö ÷Z÷X÷V÷kí^ídúXótóyóxô|ôuð‹ðôWütüoýB";


		public override void Write(byte[] buffer, int offset, int count) 
		{ 
			Encoding e=Encoding.GetEncoding(936);  //936ÊÇGB2312±àÂë£¬950ÊÇBig5±àÂë

			string str=e.GetString(buffer,offset,count).Replace("charset=gb2312","charset=big5");
  
			for(int i=0;i<str.Length;i++)
			{
				int j=_sGB.IndexOf(str[i]);
				if(j!=-1)str=str.Replace(_sGB[j],_tGB[j]);
			}
			e=Encoding.GetEncoding(System.Web.HttpContext.Current.Response.Charset);
			_sink.Write(e.GetBytes(str), 0, e.GetByteCount(str));

 
		} 
	} 
} 

