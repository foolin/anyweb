function $$(id) { return document.getElementById(id); }

function Validator() {
    this.controls = new Array();
    this.summaryctl = "errorInfo";
    this.errors = "";
    this.isIE = navigator.appName.indexOf("Netscape") == -1;
}
Validator.prototype = {
    DataType: {
        account: /^[A-Za-z][A-Za-z0-9]{4,20}$/,
        email: /^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$/,
        phone: /^((\(\d{3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}$/,
        mobile: /^((\(\d{3}\))|(\d{3}\-))?1[3|5]\d{9}$/,
        url: /^http:\/\/[A-Za-z0-9\-]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/,
        idcard: /^\d{15}(\d{2}[A-Za-z0-9])?$/,
        currency: /^\d+(\.\d+)?$/,
        number: /^\d+$/,
        date: "date",
        zip: /^[1-9]\d{5}$/,
        qq: /^[1-9]\d{4,10}$/,
        integer: /^[-\+]?\d+$/,
        double: /^[-\+]?\d+(\.\d+)?$/,
        english: /^[A-Za-z.]+$/,
        chinese: /^[\u0391-\uFFE5]+$/
    },
    Control: function(id, name, ctlid) {
        this.id = id;
        this.name = name;
        this.ctlid = ctlid;
        this.errmsg = "invalid";
        this.errtext = "*";
        this.errcss = "invalid";
        this.oktext = "√";
        this.okcss = "valid";
        this.src = null;
        this.msgctl = null;
        this.min = 0;
        this.max = 99999999;
        this.minlen = 0;
        this.maxlen = 99999999;
        this.datatype = "";
        this.format = "ymd";
        this.expression = "";
        this.checktype = 1; //1:required;2:maxlen;3:datatype;4:range;5:regular;6:custom;7:minlen
        this.succ = true;
        this.checkblur = true;
    },

    Add: function(ctl) {
        this.controls.push(ctl);
        ctl.controller = this;
    },

    Init: function() {
        for (i = 0; i < this.controls.length; i++) {
            this.controls[i].msgctl = $$(this.controls[i].id);
            if (this.controls[i].msgctl == null) {
                continue;
            }
            this.controls[i].src = $$(this.controls[i].ctlid);
            if (this.controls[i].src == null) {
                continue;
            }

            this.controls[i].src.obj = this.controls[i];

            if (this.controls[i].checkblur) {
                if (this.isIE) {
                    this.controls[i].src.attachEvent("onblur", function(e) {
                        e.srcElement.obj.controller.Validate(e.srcElement.obj);
                    });
                }
                else {
                    this.controls[i].src.addEventListener("blur", function(e) {
                        e.target.obj.controller.Validate(e.target.obj);
                    }, false);
                }
            }
        }
        var forms = this;
        $("form").each(function() {
            $(this).submit(function() {
                if (forms.Validates()) {
                    return forms.Success();
                } else {
                    return false;
                }
            });
        });
    },

    Validate: function(ctl) {
        var src = $$(ctl.ctlid);
        if (src == null) {
            return false;
        }
        //移除前后空格
        src.value = (src.value || "").replace(/^(\s|\u00A0)+|(\s|\u00A0)+$/g, "");
        ctl.succ = false;
        switch (ctl.checktype) {
            case 1:
                {
                    if (src.value && src.value.length > 0) {
                        ctl.succ = true;
                    }
                    break;
                }
            case 2:
                {
                    if (!src.value || src.value.length <= ctl.maxlen) {
                        ctl.succ = true;
                    }
                    break;
                }
            case 3:
                {
                    var type = this.DataType[ctl.datatype];
                    if (type == null) {
                        break;
                    }
                    switch (type) {
                        case "date":
                            {
                                if (src.value || this.IsDate(src.value, ctl.format)) {
                                    ctl.succ = true;
                                }
                                break;
                            }
                        default:
                            {
                                if (src.value == "" || type.test(src.value)) {
                                    ctl.succ = true;
                                    break;
                                }
                            }
                    }
                    break;
                }
            case 4:
                {
                    if (!src.value || new Number(src.value) <= ctl.max && new Number(src.value) >= ctl.min) {
                        ctl.succ = true;
                    }
                    break;
                }
            case 5:
                {
                    if (this.Exec(src.value, ctl.expression)) {
                        ctl.succ = true;
                    }
                    break;
                }
            case 6:
                {
                    if (eval(ctl.expression)) {
                        ctl.succ = true;
                    }
                    break;
                }
            case 7:
                {
                    if (src.value && src.value.length >= ctl.minlen) {
                        ctl.succ = true;
                    }
                    break;
                }
        }
        if (ctl.succ == true) {
            ctl.msgctl.className = ctl.okcss;
            ctl.msgctl.innerHTML = ctl.oktext;
        }
        else {
            ctl.msgctl.className = ctl.errcss;
            ctl.msgctl.innerHTML = ctl.errtext;
        }
    },

    Validates: function() {
        this.errors = "";
        for (i = 0; i < this.controls.length; i++) {
            this.Validate(this.controls[i]);
            if (this.controls[i].succ == false) {
                if (this.controls[i].errmsg == "invalid" && this.controls[i].errtext != "invalid") {
                    this.controls[i].errmsg = this.controls[i].errtext;
                }
                this.errors += this.controls[i].errmsg + "\r\n";
            }
        }
        if (this.errors.length > 0) {
            var sum = $$(this.summaryctl);
            if (sum != null) {
                sum.innerHTML = this.errors.replace("\r\n", "<br />");
                sum.className = "errsummary";
            }
            else
                alert(this.errors);

            return false;
        }
        return true;
    },

    Success: function() {
        return true;
    },

    Exec: function(op, reg) {
        return new RegExp(reg, "g").test(op);
    },

    IsDate: function(op, formatString) {
        formatString = formatString || "ymd";
        var m, year, month, day;
        switch (formatString) {
            case "ymd":
                m = op.match(new RegExp("^\\s*((\\d{4})|(\\d{2}))([-./])(\\d{1,2})\\4(\\d{1,2})\\s*$"));
                if (m == null) return false;
                day = m[6];
                month = parseInt(m[5]) - 1;
                year = (m[2].length == 4) ? m[2] : GetFullYear(parseInt(m[3], 10));
                break;
            case "dmy":
                m = op.match(new RegExp("^\\s*(\\d{1,2})([-./])(\\d{1,2})\\2((\\d{4})|(\\d{2}))\\s*$"));
                if (m == null) return false;
                day = m[1];
                month = parseInt(m[3]) - 1;
                year = (m[5].length == 4) ? m[5] : GetFullYear(parseInt(m[6], 10));
                break;
            default:
                break;
        }
        var date = new Date(year, month, day);
        return (typeof (date) == "object" && year == date.getFullYear() && month == date.getMonth() && day == date.getDate());
        function GetFullYear(y) { return ((y < 30 ? "20" : "19") + y) | 0; }
    }
}