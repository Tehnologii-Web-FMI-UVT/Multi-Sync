Array.prototype.inArray = function (comparer) {
    for (var i = 0; i < this.length; i++) { if (comparer(this[i])) return true; }
    return false;
}; Array.prototype.removeObject = function (object) {
    var i = this.indexOf(object); if (i < 0) { return; }
    this.splice(i, 1);
}; Array.prototype.pushIfNotExist = function (element, comparer) { if (!this.inArray(comparer)) { this.push(element); } }; Array.prototype.count = function (expr) {
    if (expr === undefined || typeof expr !== "function") { return null; }
    var count = 0; for (var i = 0; i < this.length; i++) { if (expr(this[i])) { count++; } }
    return count;
}; Array.prototype.all = function (expr) {
    for (var i = 0; i < this.length; i++) { if (!expr(this[i])) { return false; } }
    return true;
}; Array.prototype.where = function (expr) {
    if (expr === undefined || typeof expr !== "function") { return null; }
    var out = []; for (var i = 0; i < this.length; i++) { if (expr(this[i])) { out.push(this[i]); } }
    return out;
}; Array.prototype.select = function (expr) {
    if (expr === undefined || typeof expr !== "function") { return null; }
    var out = []; for (var i = 0; i < this.length; i++) { out.push(expr(this[i])); }
    return out;
}; Array.prototype.whereSelect = function (where, select) {
    if (!expr || !select || typeof where !== "function" || typeof select !== "function") { return null; }
    if (this.length === 0) { return []; }
    var out = []; for (var i = 0; i < this.length; i++) { if (where(this[i])) { out.push(expr(this[i])); } }
    return out;
}; Array.prototype.find = function (expr) {
    if (expr === undefined || typeof expr !== "function") { return null; }
    for (var i = 0; i < this.length; i++) { if (expr(this[i])) { return this[i]; } }
    return null;
}; Array.prototype.last = function (expr) {
    if (this.length === 0) { return null; }
    if (!expr || typeof (expr) !== "function") { return this[this.length - 1]; }
    var subArray = this.where(expr); if (subArray !== null) {
        if (subArray.length === 0) { return null; }
        else { return subArray[subArray.length - 1]; }
    }
    return this[this.length - 1];
}; Array.prototype.minMax = function (getMinOrMax) {
    if (this.length == 0) { return null; }
    var minMax = this[0]; for (var i = 0; i < this.length; i++) { minMax = getMinOrMax(this[i], minMax); }
    return minMax;
}; Array.prototype.aggregate = function (list) {
    if (list.length === 0) { return; }
    for (var i = 0; i < list.length; i++) { this.push(list[i]); }
}; Array.prototype.aggregateEx = function (listArray) {
    if (listArray.length === 0) { return; }
    var elements = []; for (var i = 0; i < listArray.length; i++) { for (var j = 0; j < listArray[i].length; j++) { elements.push(listArray[i][j]); } }
    this.length = 0; for (var i = 0; i < elements.length; i++) { this.push(elements[i]); }
}; Array.prototype.first = function (expr) {
    if (this.length === 0) { return null; }
    if (!expr) { return this.length > 0 ? this[0] : null; }
    for (var i = 0; i < this.length; i++) { if (expr(this[i])) { return this[i]; } }
    return null;
}; Array.prototype.addAggregated = function (array) {
    for (var i = 0; i < array.length; i++) { this.push(array[i]); }
    return this;
}; Array.prototype.any = function (expr) {
    if (this.length === 0) { return false; }
    for (var i = 0; i < this.length; i++) { if (expr(this[i])) { return true; } }
    return false;
}; Array.prototype.hasEventOccured = function (eventName) {
    if (this.length === 0) { return false; }
    for (var i = 0; i < this.length; i++) { if (this[i] === eventName) { return true; } }
    return false;
}; Array.prototype.indexWhere = function (expr) {
    if (this.length === 0) { return -1; }
    for (var i = 0; i < this.length; i++) { if (expr(this[i])) { return i; } }
    return -1;
}; Array.prototype.indicesWhere = function (expr) {
    var outData = []; if (this.length === 0) { return outData; }
    for (var i = 0; i < this.length; i++) { if (expr(this[i])) { outData.push(i); } }
    return outData;
}; Array.prototype.forEach = function (expr) {
    if (this.length === 0) { return; }
    for (var i = 0; i < this.length; i++) { if (expr(this[i])) { break; } }
}; Array.prototype.customForEach = function (expr) {
    if (this.length === 0) { return; }
    for (var i = 0; i < this.length; i++) { if (expr(this[i])) { break; } }
}; Array.prototype.count = function (expr) {
    if (this.length === 0) { return 0; }
    var count = 0; for (var i = 0; i < this.length; i++) { if (expr(this[i])) { count++; } }
    return count;
}; Array.prototype.containsByProp = function (prop, value) { var found = this.first(function (ar) { return ar[prop] !== undefined && ar[prop] === value; }); return found; }; Array.prototype.getById = function (id) {
    for (var i = 0; i < this.length; i++) { if (this[i].Id === id) { return this[i]; } }
    return null;
}; Array.prototype.groupByProp = function (propName) {
    var groups = []; for (var i = 0; i < this.length; i++) {
        var element = this[i]; if (!element) { continue; }
        var group = groups.first(function (e) { return compareByPropEx(e, element, "Key", propName); }); if (!group) { group = { Key: element[propName], Items: [] }; groups.push(group); }
        group.Items.push(element);
    }
    return groups;
}; if (!String.prototype.startsWith) { String.prototype.startsWith = function (searchString, position) { position = position || 0; return this.indexOf(searchString, position) === position; }; }
function GetMsb(n) {
    if (typeof n !== "number") { return null; }
    n = Math.floor(n); if (n === 0) { return 0; }
    return 1 * Math.pow(2, Math.floor(Math.log2(n)));
}; function IsNullOrEmptyString(str) { return str === undefined || str === null || str.IsEmpty(); }; function IsValidResult(result) { return result && result.Success; }; function ExtractHostname(url) {
    var hostname; if (url.indexOf("://") > -1) { hostname = url.split('/')[2]; }
    else { hostname = url.split('/')[0]; }
    hostname = hostname.split(':')[0]; hostname = hostname.split('?')[0]; return hostname;
}
function GetUrlParam(name) {
    var decodedUrl = decodeURIComponent(window.location.href); if (decodedUrl === undefined || decodedUrl === null)
        return null; try {
            if (decodedUrl.indexOf(name) < 0) { return null; }
            return decodedUrl.substring(decodedUrl.indexOf(name) + name + "=".length);
        } catch (e) { return null; }
}; function Copy(obj) {
    if (obj === undefined || obj === null)
        return obj; if (_isObservable(obj)) { return JSON.parse(JSON.stringify(obj())); }
    return JSON.parse(JSON.stringify(obj));
}; function IsValidateEmail(email) { var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/; return re.test(String(email).toLowerCase()); }; function GetGrayScale(colorUInt32) { var temp = new Uint8Array(3); temp[0] = parseInt((colorUInt32 & 0xff000000).toString(16).substr(0, 2), 16); temp[1] = parseInt((colorUInt32 & 0x00ff0000).toString(16).substr(0, 2), 16); temp[2] = parseInt((colorUInt32 & 0x0000ff00).toString(16).substr(0, 2), 16); return (temp[0] * 0.3) + (temp[1] * 0.59) + (temp[2] * 0.11); }; function TriggerKeypress(e, which) { var event = $.Event('keypress'); event.which = which; $(e).trigger(event); }; function TriggerKeyup(e, which) { var event = $.Event('keyup'); event.which = which; $(e).trigger(event); }; function TriggerKeydown(e, which) { var event = $.Event('keydown'); event.which = which; $(e).trigger(event); }; function uuid() { return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) { var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8); return v.toString(16); }); }
function suuid() { return 'xxxx-4xxxx'.replace(/[xy]/g, function (c) { var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8); return v.toString(16); }); }
function ToggleChecked(element, triggerChangeEvent) {
    triggerChangeEvent = Default(triggerChangeEvent, false); if ($(element).is(":checked")) { $(element).prop("checked", false); }
    else { $(element).prop("checked", true); }
    triggerChangeEvent && $(element).trigger("change");
}
function ToggleCheckedOnSibling(me, selector, triggerChangeEvent) {
    triggerChangeEvent = Default(triggerChangeEvent, false); if ($(me).is(":checked")) { $(me).siblings(selector).prop("checked", false); }
    else { $(me).siblings(selector).prop("checked", true); }
    triggerChangeEvent && $(element).trigger("change");
}
function ObjectToQuery(obj) {
    var str = []; for (var p in obj) { if (obj.hasOwnProperty(p)) { str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p])); } }
    return str.join("&");
}
function BindRawFormValidations(form) { var $form = $(form); $form.unbind(); $form.data("validator", null); $.validator.unobtrusive.parse($form); return $form; }
function ValidateRawForm(formId) { var $form = BindRawFormValidations($("#" + formId)); $form.validate(); return $form.valid(); }
function IsFormValid(formId) { var $form = $("#" + formId); $form.validate(); return $form.valid(); }
function IsFormValidEx(form) { var $form = $(form); $form.validate(); return $form.valid(); }
function Require(url, callback) { var e = document.createElement("script"); e.src = url; e.type = "text/javascript"; e.addEventListener('load', callback); document.getElementsByTagName("head")[0].appendChild(e); }
function PInteger(event) { if ((event.keyCode === 46 || event.keyCode === 8) || (event.keyCode >= 35 && event.keyCode <= 39) || (event.keyCode === 9) || (event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode >= 96 && event.keyCode <= 105)) { return true; } else { event.preventDefault(); return false; } }
function IsInteger(obj) { return !isNaN(parseInt(obj)) && isFinite(obj); }
function ExtractParamsFromQueryString(url) {
    var params = {}; if (!url) { return params; }
    var splitByQ = url.split('?'); if (!splitByQ[1]) { return params; }
    var splitByA = splitByQ[1].split('&'); splitByA.forEach(function (t) { var parts = t.split('='); params[parts[0]] = parts[1]; })
    return params;
}
function ExtractUserTokenParamsFromQueryString(url) {
    var params = {}; if (!url) { return params; }
    var splitByQ = url.split('?'); if (!splitByQ[1]) { return params; }
    var splitByA = splitByQ[1].split('&'); splitByA.forEach(function (t) { var parts = t.split('code='); params["code"] = parts[1]; })
    return params;
}
function GetPaddingLeft(e) {
    var padding = $(e).css("padding"); if (!padding || !padding.trim().length) { return 0; }
    var parts = padding.split(' '); return parseInt(parts[parts.length - 1]);
}
function MemberwiseCopy(obj) {
    var newObject = {}; for (var key in obj) { newObject[key] = obj[key]; }
    return newObject;
}
function ObjectAssign(baseObj, obj) {
    for (var key in obj) { baseObj[key] = obj[key]; }
    return newObject;
}
function ObjectMerge(baseObj, obj) {
    var newObject = MemberwiseCopy(baseObj); for (var key in obj) { newObject[key] = obj[key]; }
    return newObject;
}
function Default(val, defaultVal) {
    if (val === undefined || val === null) { return defaultVal; }
    return val;
}
function clearPhotoId(targetId) { $("#" + targetId).val(""); $("#" + targetId).html(""); $("#label-upload").removeClass('display-none') }
function OnPhotoIdPicked(e, targetId) {
    if (!e.files || !e.files.length) { return true; }
    $("#" + targetId).html(e.files[0].name + "<span onclick=\"clearPhotoId('" + targetId + "');\" title='Clear' class='label-clear'>x</span>"); $("#label-upload").addClass('display-none')
}
function PostFile(url, formData, successCallback, failureCallBack) { $.ajax({ type: "POST", url: url, data: formData, dataType: "json", contentType: false, processData: false, success: successCallback, failure: failureCallBack }); }
function ValidateFileExtension(file) { return validate(file, [".jpg", ".JPG", ".jpeg", ".JPEG", ".pdf", ".png", ".docx"]); }
function validate(uploadFile, validFileExtensions) {
    var oinput = uploadFile; var sFileName = oinput.name; if (sFileName.length > 0) { for (var j = 0; j < validFileExtensions.length; j++) { var sCurExtension = validFileExtensions[j]; if (sFileName.substr(sFileName.length - sCurExtension.length, sCurExtension.length).toLowerCase() == sCurExtension.toLowerCase()) { return true; } } }
    return false;
}
String.prototype.IsEmpty = function () { return this.trim() === ""; }; Date.prototype.toIsoString = function () {
    if (typeof (moment) !== "undefined") { return moment(this).format(); }
    var tzo = -this.getTimezoneOffset(), dif = tzo >= 0 ? '+' : '-', pad = function (num) { var norm = Math.floor(Math.abs(num)); return (norm < 10 ? '0' : '') + norm; }; return this.getFullYear() +
        '-' + pad(this.getMonth() + 1) +
        '-' + pad(this.getDate()) +
        'T' + pad(this.getHours()) +
        ':' + pad(this.getMinutes()) +
        ':' + pad(this.getSeconds()) +
        dif + pad(tzo / 60) +
        ':' + pad(tzo % 60);
}; 
$.extend($.expr[":"], { containsExact: $.expr.createPseudo ? $.expr.createPseudo(function (text) { return function (elem) { return $.trim(elem.innerHTML.toLowerCase()) === text.toLowerCase(); }; }) : function (elem, i, match) { return $.trim(elem.innerHTML.toLowerCase()) === match[3].toLowerCase(); }, containsExactCase: $.expr.createPseudo ? $.expr.createPseudo(function (text) { return function (elem) { return $.trim(elem.innerHTML) === text; }; }) : function (elem, i, match) { return $.trim(elem.innerHTML) === match[3]; }, containsRegex: $.expr.createPseudo ? $.expr.createPseudo(function (text) { var reg = /^\/((?:\\\/|[^\/])+)\/([mig]{0,3})$/.exec(text); return function (elem) { return reg ? RegExp(reg[1], reg[2]).test($.trim(elem.innerHTML)) : false; }; }) : function (elem, i, match) { var reg = /^\/((?:\\\/|[^\/])+)\/([mig]{0,3})$/.exec(match[3]); return reg ? RegExp(reg[1], reg[2]).test($.trim(elem.innerHTML)) : false; } }); function isMobileTablet() {
    var check = false; (function (a) {
        if (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino|android|ipad|playbook|silk/i.test(a) || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(a.substr(0, 4)))
            check = true;
    })(navigator.userAgent || navigator.vendor || window.opera); return check;
}
function readCookie(name) {
    var nameEQ = name + "="; var ca = document.cookie.split(';'); for (var i = 0; i < ca.length; i++) { var c = ca[i]; while (c.charAt(0) == ' ') c = c.substring(1, c.length); if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length); }
    return null;
}
Array.prototype.unique = function () { return this.filter(function (value, index, self) { return self.indexOf(value) === index; }); }
function ShowLoading() { $('.loading').css('display', 'inline-block') }
function HideLoading() { $('.loading').css('display', 'none') }
function GenerateGuid() { return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) { var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8); return v.toString(16); }); }
function DExport(module, suffix) { suffix = Default(suffix, ""); Object.keys(module).forEach(function (key) { window[key + suffix] = module[key]; }); }; function JExport(exports) { Object.keys(exports).forEach(function (exName) { window[exName] = exports[exName]; }); }
function convertModelToFormData(data, form, namespace) {
    data = Default(data, {})
    form = Default(form, null)
    namespace = Default(namespace, '')
    var files = {}; var model = {}; for (var propertyName in data) { if (data.hasOwnProperty(propertyName) && data[propertyName] instanceof File) { files[propertyName] = data[propertyName] } else { model[propertyName] = data[propertyName] } }
    model = JSON.parse(JSON.stringify(model))
    var formData = form || new FormData(); for (var propertyName in model) {
        if (!model.hasOwnProperty(propertyName) || !model[propertyName]) continue; var formKey = namespace ? namespace + "[" + propertyName + "]" : propertyName; if (model[propertyName] instanceof Date)
            formData.append(formKey, model[propertyName].toISOString()); else if (model[propertyName] instanceof File) { formData.append(formKey, model[propertyName]); }
        else if (model[propertyName] instanceof Array) {
            for (var index = 0; index < model[propertyName].length; index++) {
                var element = model[propertyName][index]; var tempFormKey = formKey + "[" + index + "]"; if (typeof element === 'object') { this.convertModelToFormData(element, formData, tempFormKey); }
                else formData.append(tempFormKey, element.toString());
            }
        }
        else if (typeof model[propertyName] === 'object' && !(model[propertyName] instanceof File))
            this.convertModelToFormData(model[propertyName], formData, formKey); else { formData.append(formKey, model[propertyName].toString()); }
    }
    for (var propertyName in files) { if (files.hasOwnProperty(propertyName)) { formData.append(propertyName, files[propertyName]); } }
    return formData;
}
function ConvertListToObject(list, parameterName) {
    var object = {}; if (list !== undefined && list.length > 0 && parameterName !== undefined) { for (var i = 0; i < list.length; i++) { var newName = parameterName + i; object[newName] = list[i].toLowerCase(); } }
    return object;
}
function ExtractListFromQueryString(url, parameterName) {
    var list = []; if (url !== undefined && parameterName !== undefined) { var params = ExtractParamsFromQueryString(location.href); var count = 0; while (params[parameterName + count] !== undefined) { list.push(params[parameterName + count].toLowerCase()); count++; } }
    return list;
}
function ListContainId(list, id) {
    var contain = false; if (list !== undefined && list.length > 0 && id !== undefined) { for (var i = 0; i < list.length; i++) { if (list[i].toLowerCase() == id.toLowerCase()) { contain = true; return contain; } } }
    return contain;
}
function isInteger(obj) { return !isNaN(parseInt(obj)) && isFinite(obj); }; function loadDefaultPictureUser(img) {
    if (typeof (img) == "undefined" || img == null) { return; }
    img.src = DEFAULT_PICTURE_URL;
}
function JExport(exports, prefix, postfix) { prefix = Default(prefix, ""); postfix = Default(postfix, ""); Object.keys(exports).forEach(function (k) { window[postfix + k + prefix] = exports[k]; }); }
function NamedEntityViewModel(parent) { var self = this; self.Parent = parent; self.Id = ko.observable(); self.Name = ko.observable(); self.Init = function (data) { self.Id(data.Id); self.Name(data.Name); } }
function setCurrentPage() { var currentPageClass = "current-page"; $(".desktop-menu > div > a").removeClass(currentPageClass); $(".mobile-menu .d-menu-item").removeClass(currentPageClass); var elementDesktopMenu = ".desktop-menu > div > a"; var elementMobileMenu = ".mobile-menu .d-menu-item"; path = window.location.pathname; if (path == "/") { $(elementDesktopMenu + "[href='/']").addClass(currentPageClass); $(elementMobileMenu + "[href='/']").addClass(currentPageClass); } else if (path.includes("/about-us")) { $(elementDesktopMenu + "[href='/about-us']").addClass(currentPageClass); $(elementMobileMenu + "[href='/about-us']").addClass(currentPageClass); } else if (path.includes("/projects")) { $(elementDesktopMenu + "[href='/projects']").addClass(currentPageClass); $(elementMobileMenu + "[href='/projects']").addClass(currentPageClass); } else if (path.includes("/products")) { $(elementDesktopMenu + "[href='/products']").addClass(currentPageClass); $(elementMobileMenu + "[href='/products']").addClass(currentPageClass); } else if (path.includes("/our-process")) { $(elementDesktopMenu + "[href='/our-process']").addClass(currentPageClass); $(elementMobileMenu + "[href='/our-process']").addClass(currentPageClass); } else if (path.includes("/submit-project")) { $(elementDesktopMenu + "[href='/submit-project']").addClass(currentPageClass); $(elementMobileMenu + "[href='/submit-project']").addClass(currentPageClass); } else if (path.includes("/blog")) { $(elementDesktopMenu + "[href='/blog']").addClass(currentPageClass); $(elementMobileMenu + "[href='/blog']").addClass(currentPageClass); } else if (path.includes("/jobs")) { $(elementDesktopMenu + "[href='/jobs']").addClass(currentPageClass); $(elementMobileMenu + "[href='/jobs']").addClass(currentPageClass); } else if (path.includes("/contact-us")) { $(elementDesktopMenu + "[href='/contact-us']").addClass(currentPageClass); $(elementMobileMenu + "[href='/contact-us']").addClass(currentPageClass); } else if (path.includes("/services")) { $(elementDesktopMenu + "[href='/services']").addClass(currentPageClass); $(elementMobileMenu + "[href='/services']").addClass(currentPageClass); } }
function scrollToSection(id) {
    var barHeight = 300; if (window.innerWidth < 767) { barHeight = 100; }
    $('html, body').animate({ scrollTop: $("#" + id).offset().top - barHeight }, 1000);
}