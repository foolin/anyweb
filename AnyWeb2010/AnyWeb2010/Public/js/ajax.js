/* Type */
Object.isNull=function(o){return(null==o||undefined==o);}
var __sp=String.prototype;
__sp.endsWith=function(suffix){
	return(this.substr(this.length-suffix.length)==suffix);
}
__sp.startsWith=function(prefix){return(this.substr(0,prefix.length)==prefix);}
__sp.lTrim=__sp.trimStart=function(){return this.replace(/^\s*/,"");}
__sp.rTrim=__sp.trimEnd=function(){return this.replace(/\s*$/,"");}
__sp.trim=function(){return this.trimStart().trimEnd();}
__sp.format=function(){
	var s=this;
	var aRE=__sp.format.aRegExp;
	var iCount=arguments.length;
	for(var i=0;i<iCount;i++){
		if(!aRE[i]){
			aRE[i]=new RegExp("\\{"+i+"\\}","g");}
		s=s.replace(aRE[i],arguments[i]);
	}
	return(s);
}
__sp.format.aRegExp=[];
String.isEmpty=function(string){return Object.isNull(string)||""==string;}

function $(){
	var elements = new Array();
	for( var i=0; i<arguments.length; i++){
		var element = arguments[i];
		if( typeof(element) == "string"){
			element = document.getElementById(element);
		}
		
		if( arguments.length = 1){
			return element;
		}
		else{
			elements.push(element);
		}		
	}
	
	return elements;
}

/* Ajax */
//构造函数
function Ajax(){}
//定义原型
Ajax.prototype = {
	err_404		: "Page not found!",
	err_500		: "Application error!",
	
	Execute		: function(url, callback, eventCtl, statusCtl){
		this.eventCtl = eventCtl;
		this.statusCtl = statusCtl;
		
		if( this.eventCtl != undefined ){
			this.eventCtl.disabled = true;
		}
		if( this.statusCtl!= undefined){
			this.statusCtl.innerText = "Processing...";
			this.statusCtl.className = "processInfo";
		}
		this.Open(url,"GET","",callback);
	},
	
	Open : function(url,method,data,onsucc,onerror,resultFormat){
		var req = this.GetRequest();
		this.succCallback = onsucc;
		this.errCallback = onerror?onerror:this.ShowError;
		this.resultFormat = resultFormat?resultFormat:"text";
		if( req == null){
			this.errCallback("Not Support Ajax!");
			return;
		}
		else{
			this.request = req;
		}
		
		var loader = this;
        this.request.onreadystatechange = function(){loader.StateChange();};
		if( method == "POST"){
			req.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
		}
		req.open(method,url,true);
		req.send(data);
	},
			
	StateChange : function(){
		var req = this.request;
		if( req.readyState == 4){
			if( req.status == 200){
				if( this.resultFormat == "xml"){
					this.succCallback(req.responseXML);
				}
				else{
					var resText = req.responseText;
					if( !resText.startsWith("result:")){
						this.errCallback("System Error!");
					}
					else{
						if( this.statusCtl !=undefined){
							if( resText.substring( 7, 8) == "0"){
								this.statusCtl.className="okinfo";
							}
							else{
								this.statusCtl.className = "errinfo";
							}
							this.statusCtl.innerHTML = resText.substring( resText.indexOf("|") + 1, resText.length);
						}
						this.succCallback(resText.substring( 7, resText.indexOf("|")), resText.substring( resText.indexOf("|") + 1, resText.length));	
					}				
					
					if( this.eventCtl != undefined){
						this.eventCtl.disabled = false;
					}
				}
			}
		}
		else{
		}
	},

	GetRequest : function(){
		var req = null;
		if( window.XMLHttpRequest){
			req = new XMLHttpRequest();
			if(req.overrideMimeType){
                 req.overrideMimeType("text/xml");
            }
           // alert("firefox");
		}
		else{
			if(window.ActiveXObject){
				try{
					req = new ActiveXObject("Msxml3.XMLHTTP");
				}
				catch(e){
					try{
						req = new ActiveXObject("Msxml2.XMLHTTP");
					}
					catch(e){
						try{
							req = new ActiveXObject("Microsoft.XMLHTTP");
						}
						catch(e){
						}
					}
				}				
			}
		}
		
		return req;
	},
	
	ShowError : function(err){
		window.alert(err);
	}
}