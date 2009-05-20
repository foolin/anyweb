//Level,ID,Text,Url,children direction
function MenuItem(level,id,text,url,target,cd)
{
    this.level = level;
    this.id = id;
    this.text = text;
    this.url = url;
    this.target = target;
    this.direction = cd;
    this.parent = null;
    this.index = 0;
    //Children Area
    this.area = document.createElement("DIV");    
    this.area.className = "child";
    this.area.style.visibility = "hidden";
	this.area.style.position = "absolute";
	this.area.style.left = "0px";
	//Add all child area to document,there need a container named "menuContainer"
	menuContainer.appendChild(this.area);
	
	//Bind methods
    this.focus = Item_Focus;
    this.add = Item_Add;
    this.addSeparator = AddSeparator;
    this.blur = Item_Blur;
    this.bind = Item_Bind;

	//MenuItem Html Object
	if(level == 1)
	{
	    var topIt = document.createElement("DIV");
	    topIt.className = "parent";
	    topIt.innerText = text;
		this.bind(topIt);
	}
    else
    {
        var a = document.createElement("A");
        a.innerText = text;
        if( target != "" && target != null)
            a.target = target;
		this.bind(a);
    }
    
    //Child menus
    this.children = new Array();   
}

//Bind a html object to the menu item
function Item_Bind(e)
{
    e.obj = this;
    e.objtype = "menu";
    if(navigator.appName.indexOf("Netscape")>-1)
    {
        e.addEventListener("mouseover",Menu_MouseOver,false);
        e.addEventListener("mouseout",Menu_MouseOut,false);
    }
    else
    {
        e.attachEvent("onmouseover", Menu_MouseOver);
        e.attachEvent("onmouseout", Menu_MouseOut);
    }
    this.element = e;
}

//Get focus
function Item_Focus()
{
    if( this.area != null)
    {
        //Close the same level actived menus
        CloseMenu(this.level);
        
        //Save actived menu of all levels to window.activeMenuArea
        if( !window.activeMenuArea )
        {
            window.activeMenuArea = new Array();
        }
        
        //Set active menu of current level
        window.activeMenuArea[this.level] = this.area;
        

                    
        //Expand child area if has children
        if( this.children.length > 0)
        {
			if( this.direction == "h") //horizontal
			{
		        //////////////////select iframe ,Fix size and Location////////////////
		        var iframe2 = document.getElementById("if2");
                if(iframe2 != null)
                {
                   iframe2.style.top = getoffset(this.element)[0];
                   iframe2.style.left = getoffset(this.element)[1] + this.element.offsetWidth;
         
                   iframe2.style.height = this.area.clientHeight +2;
                   iframe2.style.width = this.area.clientWidth +2;
                }
            
				this.area.style.left = getoffset(this.element)[1] + this.element.offsetWidth;
				this.area.style.top = getoffset(this.element)[0];
				
				  //////////////show iframe///////////////////////
				 iframe2.style.visibility = "visible";	
			}
			else	//vertical
			{	
			
		        //////////////////select iframe ,Fix size and Location////////////////
		        var iframe1 = document.getElementById("if1");
		        if(iframe1 != null)
                {
                   iframe1.style.top =  getoffset(this.element)[0] + this.element.offsetHeight;
                   iframe1.style.left = getoffset(this.element)[1];
                    
                 	iframe1.style.height = this.area.clientHeight +2;
                 	iframe1.style.width = this.area.clientWidth + 2;
                }
                    
				this.area.style.left = getoffset(this.element)[1];
				this.area.style.top = getoffset(this.element)[0] + this.element.offsetHeight;
				
			    //////////////show iframe///////////////////////
				iframe1.style.visibility = "visible";
			}
			
            this.area.style.visibility = "visible";
        }
        if( this.url == "")
        {
            this.element.href = "javascript:void(0);";
        }
        else
        {
            this.element.href = this.url;
        }
    }
}

//Lost focus,(the close function put on document.onclick event)
function Item_Blur()
{
}

//Add child menu
function Item_Add(child)
{
    this.children.push(child);

    this.area.appendChild(child.element);
    if( this.level > 1)
        this.element.className = "hasChild";
    child.parent = this;
    child.index = this.children.length - 1;
}

//Add separator
function AddSeparator()
{
    var separator = document.createElement("HR");
    separator.className = "separator";
    separator.size = "1px";
    separator.color = "#ccc";
    this.area.appendChild(separator);	
}

//Event on mouse over menuitem
function Menu_MouseOver(e)
{
    if( e.target && e.target.obj)
        e.target.obj.focus();
    if( e.srcElement && e.srcElement.obj)
        e.srcElement.obj.focus();      
}

//Event on mouse out menuitem
function Menu_MouseOut(e)
{
    if( e.target && e.target.obj)
    {
        e.target.obj.blur();
    }
    if( e.srcElement && e.srcElement.obj)
    {
        e.srcElement.obj.blur();
    }
        
}

//Click item menu
function Menu_Click(e)
{
    if( e.target)
    {
        if(e.target.obj && e.target.obj.url != null && e.target.target != "_blank")
            window.location = e.target.obj.url;
    }
    else if( event.srcElement.obj && event.srcElement.obj.url != null && event.srcElement.target != "_blank")
    {
        window.navigate(event.srcElement.obj.url);
    }
}

//Close the active menu of a special level
function CloseMenu(level)
{      
    if( window.activeMenuArea != null)
    {
        //////////////iframe///////////////////////
        if(level == 2)
        {
            //////////////hide iframe///////////////////////
            var iframe2 = document.getElementById("if2");
            if(iframe2 != null)
            {
                iframe2.style.visibility = "hidden";
            }  
        }
        
        if( level == 1 || level == 0)
        {
            for(i=0;i<window.activeMenuArea.length;i++)
            {	
                if( window.activeMenuArea[i])
                {
                    window.activeMenuArea[i].style.visibility = "hidden"; 
                }
                
                //////////////hide iframe///////////////////////
                var iframe1 = document.getElementById("if1");
            
                var iframe2 = document.getElementById("if2");
                if(iframe1 != null)
                {
                    iframe1.style.visibility = "hidden";
                }
                
                if(iframe2 != null)
                {
                    iframe2.style.visibility = "hidden";
                }  
            }
        }
        else
        {
            if( window.activeMenuArea[level])
            {
                window.activeMenuArea[level].style.visibility = "hidden";         
            }
        }
    }
}

function getoffset(e) 
{  
 var t=e.offsetTop;  
 var l=e.offsetLeft;  
 while(e=e.offsetParent) 
 {  
  t+=e.offsetTop;  
  l+=e.offsetLeft;  
 }  
 var rec = new Array(1); 
 rec[0]  = t; 
 rec[1] = l; 
 return rec; 
} 


//Close all menus on document.onclick
if(navigator.appName.indexOf("Netscape")>-1)
{
    document.addEventListener("click",Document_OnClick,false);
}
else
{
    document.attachEvent("onclick", Document_OnClick);
}
function Document_OnClick()
{
    if(navigator.appName.indexOf("Netscape")>-1)
    {
        CloseMenu(0);
    }
    else if(!event.srcElement.type || event.srcElement.objtype !="menu")
    {
        CloseMenu(0);
    }    
}
