//�ж�������Ƿ�ΪIE
function isIE(){
      return (document.all && window.ActiveXObject && !window.opera) ? true : false;
} 

//�ж�������Ƿ���ie
var isFF = navigator.userAgent.indexOf("Firefox") > 0;

//��Ϊ��ҳ
function HomePage(){
    if(isIE){
        this.style.behavior='url(#default#homepage)';this.setHomePage(this.document.location.href);
    }
    return false;
}

//����ղ�
function Love(){
    if(isIE){
        window.external.AddFavorite(this.document.location.href,'���𹤷���ѵ������');
    }
    if(isFF){
        alert("����������Firefox���ղؿɰ� Ctrl + D");
    }
    return false;
}