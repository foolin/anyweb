// JScript File


function Sort(field)
	{
		var loc = document.location.href;
		var idx = loc.indexOf("sort=");
		var start,end;
		start="";end="";
		if(idx<0)
		{
			if(loc.indexOf("?")>0) loc+="&sort="+field+"%20asc"; else loc+="?sort="+field+"%20asc";
		}
		else
		{
			start = loc.substring(0, idx);
			if(loc.indexOf("sort="+field+"%20asc")>0) start += "sort=" + field + "%20desc"; else start += "sort=" + field + "%20asc";
			var idx2 = loc.indexOf("&", idx+5);
			if(idx2>0) end = loc.substring(idx2, loc.length);
			loc = start + end;
		}
		idx = loc.indexOf("pid1=");
		if(idx > 0)
		{
			if(loc.indexOf("&", idx+4) > 0) 
				loc=loc.substring(0, idx) + "pid1=1" + loc.substring(loc.indexOf("&", idx+4), loc.length);
			else
				loc=loc.substring(0, idx) + "pid1=1";
		}
		document.location = loc;
	}
	
document.write('<scr'+'ipt type="text/javascript" src="public/validator.js"></scr'+'ipt>');
document.write('<scr'+'ipt type="text/javascript" for="window" event="onload">Validator.BoundControls();</scr'+'ipt>');