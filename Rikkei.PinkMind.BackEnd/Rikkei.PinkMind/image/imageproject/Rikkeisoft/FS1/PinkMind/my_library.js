//my library
function id(id_a){return document.getElementById(id_a+'')}

function getclass(getclass_b){return document.getElementsByClassName(getclass_b+'')}
function getClass(getclass_c){return document.getElementsByClassName(getclass_c+'')}

function tag(tag_c){return document.getElementsByTagName(tag_c+'')}

function value(val_a){return id(val_a+'').value}

function full_screen(sakure, jjjjj){
var jjjjj = jjjjj==null?20:jjjjj
var sakure = /[A-Za-z_]/.test(sakure)?sakure:''
    var div = createElement('div'); my(div).css('width', '100%');my(div).css('height', '100%'); my(div).background('rgba(0,0,0,'+ jjjjj/100 +')'); my(div).css('position', 'fixed');div.id=sakure; my(div).css('top', 0); my(div).css('left', 0); my(div).css('zIndex', 9999); my(document.body).append(div)
return div
}

var device = {
fullLang: navigator.language,
fullLanguage: navigator.language,
lang: navigator.language.slice(0,2),
language: navigator.language.slice(0,2),
OS: navigator.userAgent.substring(navigator.userAgent.indexOf("(")+1, navigator.userAgent.indexOf(")")).replace(/_/g,"."),
network: navigator.onLine,
type: navigator.platform,
cookie: navigator.cookieEnabled,
appVersion: navigator.appVersion,
platform: navigator.platform,
userAgent: navigator.userAgent,
width: screen.width,
height: screen.height,
browserWidth: screen.availWidth,
browserHeight: screen.availHeight,
numberColor: screen.colorDepth,
appName: navigator.appName,
appCodeName: navigator.appCodeName,
appVersion: navigator.appVersion,
product: navigator.product,
}

//Math object

function random(random_f){return Math.random()*random_f};
function rand(rand_f){return Math.random()*rand_f}
function abs(abs_g){return Math.abs(abs_g)};
function floor(floor_h){return Math.floor(floor_h)};
function pow(pow_i,pow_k){return Math.pow(pow_i,pow_k)};
function sqrt(sqrt_l){return Math.sqrt(sqrt_l)};
function sin(sim_m){return Math.sin(sin_m)};
function cos(cos_n){return Math.cos(cos_n)};
function tan(tan_o){return Math.tan(tan_o)};
function cot(cot_a){return 1/Math.tan(cot_a)};
function ceil(ceil_p){return Math.ceil(ceil_p)};
function round(round_q){return Math.round(round_q)};
function sin_i(sin_i_a){return Math.asin(sin_i_a)};
function cos_i(cos_i_a){return Math.acos(cos_i_a)};
function tan_i(tan_i_a){return Math.atan(tan_i_a)};
function cot_i(cot_i){return Math.atan2(cot_i)};
function number(Num_r){return Number(Num_r)};
function Num(num_x){return Number(num_x)}
function num(num_y){return Number(num_y)}
function number(num_z){return Number(num_z)}
function Bool(Bool_t){return Boolean(Bool_t)};
function bool(bool_t){return Boolean(bool_t)}
 PI = pi = Math.PI;
function dex(dex_a){if(dex_a.toString(16).length<2){return "0"+dex_a.toString(16)}else{return dex_a.toString(16)}};
function DEX(DEX_A){return dex(DEX_A)}
function bin(bin_a){return bin_a.toString(2)}
function BIN(BIN_A){return bin(BIN_a)}

function rand_color(){
return "rgb("+round(rand(255))+", "+round(rand(255))+", "+round(rand(255))+")"
}
function color_rand(){rand_color()}

function tach_so(tach_so_a){
var num_out=str_out='',ki_tu_true = [1,2,3,4,5,6,7,8,9,0,'.'];for(var i=0;i<tach_so_a.length;i++){var license = false;for(var z=0;z<11;z++){if(tach_so_a[i]==ki_tu_true[z]){num_out+=tach_so_a[i];var  license=true}};if(!license){str_out+=tach_so_a[i]}};return {number: Num(num_out), string: str_out}}
//xong thuật toán tách string và number

 function createElement(tag_element){return document.createElement(tag_element+'')}
function createTextNode(node_text){return document.createTextNode(node_text+'')}
function createText(Node_text){return document.createTextNode(node_text+'')}
function createAudio(audio_link, control){var audio = new Audio(audio_link+'');audio.controls = (control)?true:false;return audio}
function createImage(link_img, width_img, height_img){var img_a = new Image(link_img+'');if(width_img){img_a.width = width_img};if(height_img){img_a.height = height_img};return img_a}
function createVideo(link_video){var video_a = createElement("video");video_a.src = link_video+'';return video_a}

function deg_radian(radi_a) {return radi_a*Math.PI/180}
function radian_to_deg(deg_a){return deg_a*180/Math.PI}
function deg_to_radian(radi_b){return deg_radian(radi_b)}
function radian_deg(Deg_a){return deg_a*180/Math.PI}

function toArray(string_z){return string_z.split('', string_z.length)}
function string_array(string_m){return toArray(string_m)}
function string_to_array(string_n){return toArray(string_n)}

function hex_rgb(hex_color){
if(hex_color.length==7){var red = [hex_color[1],hex_color[2]], green = [hex_color[3],hex_color[4]], blue = [hex_color[5],hex_color[6]]}

else if(hex_color.length==4){var red = hex_color[1], green = hex_color[2], blue = hex_color[3]}

else{console.log('lỗi tham số truyền vào hàm hex_rgb('+hex_color+')'); return null;}
return "rgb("+hexa_dec(red)+","+hexa_dec(green)+","+hexa_dec(blue)+")"
}

function hexa_dec(hexa){
hexa = hexa.length<2?hexa+'0':hexa
	var m = [hexa[0],hexa[1]]
for(var i=0;i<2;i++){
if(m[i]=="a"){m[i] = 10}
else if(m[i]=="b"){m[i] = 11}
else if(m[i]=="c"){m[i] = 12}
else if(m[i]=="d"){m[i] = 13}
else if(m[i]=="e"){m[i] = 14}
else if(m[i]=="f"){m[i] = 15}
}
return Number(m[0]*16)+Number(m[1])
}

function hex_dec(hexa){
hexa = hexa.length<2?'0'+hexa:hexa
	var m = [hexa[0],hexa[1]]
for(var i=0;i<2;i++){
var mi = m[i]
if(mi=="a"||mi=="A"){m[i] = 10}
else if(mi=="b"||mi=="B"){m[i] = 11}
else if(mi=="c"||mi=="C"){m[i] = 12}
else if(mi=="d"||mi=="D"){m[i] = 13}
else if(mi=="e"||mi=="E"){m[i] = 14}
else if(mi=="f"||mi=="F"){m[i] = 15}
}
return Number(m[0]*16)+Number(m[1])
}



function rgb_number(ma_rgb){
var id_num = 1, hex1 = hex2 = hex3 = ''
 for(var k=4;k<ma_rgb.length-1;k++){
	if(ma_rgb[k]==","){id_num++; continue}
  if(id_num==1){hex1+=ma_rgb[k]}
else if(id_num==2){hex2+=ma_rgb[k]}
else if(id_num==3){hex3+=ma_rgb[k]}
 }
 return [hex1,hex2,hex3]
}
function rgb_hex(_ma_rgb){
	var _hex1 = rgb_number(_ma_rgb)[0]
	var _hex2 = rgb_number(_ma_rgb)[1]
	var _hex3 = rgb_number(_ma_rgb)[2]
return "#"+dec_hex(_hex1)+dec_hex(_hex2)+dec_hex(_hex3)
}
function dec_hex(a1){
	var a2 = Number(a1).toString(16)
   if(a2.length<2){a2="0"+a2}
  return a2
}

function bin_dec(bin){var hex=0,bin=bin+'';for(var i = 0;i<bin.length;i++){hex += Number(bin[i])*pow(2,bin.length-1-i);if(!(bin[i]==0||bin[i]==1)){hex='lỗi';console.log('lỗi tham số truyền vào hàm bin_dec('+bin+')');break};};return hex}

function foreach(json){
 var k = new Array()
    var string = json.slice(2, json.length-2)
  var arr = string.split(',', string.length)
  	for(var i=0;i<arr.length;i++){
  	    var locale = arr[i].search(':')
  	    var key = arr[i].slice(0,locale)
  	    var val = arr[i].slice(locale+1,arr[i].length)
  	    var sli = [key,val]
  	    k.push(sli)
  	}
  return k
}

function my(elm){
if(typeof elm==='string'){
var test = elm, index = index_ = child_index = '', index_child = test.indexOf(' child(')
if(test[0]===' '){var test = test.replace(/ /, '')}
if(elm==='body'){var elm=document.body}
else if(elm==='document'){elm=document}
else if(test[0]==='#'){

if(index_child>=0){
 for(var i=index_child+7;i<test.length;i++){
            if(test[i]===')'){break}
             child_index += test[i].toString()
  }
        if(index_child==''){console.log('yêu cầu nhập 1 số trong biểu thức child()');return}
	else{var elm = id(test.slice(test.indexOf('#')+1, test.indexOf(' '))).children[child_index]}
if(elm==null){console.log('lỗi! yêu cầu nhập đúng cú pháp hàm my("'+test+'") hoặc kiểm tra element tồn tại');return}
    }

else{var elm = id(test.replace('#', ''));if(test.indexOf(' ')>=0){console.log('lỗi! my("'+elm+'")')}}}
else if(test[0]==='.'){
var index_eq = test.indexOf(' eq(')
var _class_ = test.slice(test.indexOf('.')+1, test.indexOf(' ')).replace(' ','').toString()
    if(index_eq>=0){
        for(var i=index_eq+4;i<test.length;i++){
            if(test[i]===')'){break}
             index += test[i].toString()
        }
        if(index==''){console.log('yêu cầu nhập 1 số trong biểu thức eq()');return}
	else{
	
	if(index_child>=0){
 for(var i=index_child+7;i<test.length;i++){
            if(test[i]===')'){break}
             child_index += test[i].toString()
  }
        if(index_child==''){console.log('yêu cầu nhập 1 số trong biểu thức child()');return}
	else{var elm = getclass(_class_)[number(index)].children[child_index]}
if(elm==null){console.log('lỗi! yêu cầu nhập đúng cú pháp hàm my("'+test+'") hoặc kiểm tra element tồn tại');return}
    }
    
else{var elm = getclass(_class_)[number(index)]}}
if(elm==null){console.log('lỗi! yêu cầu nhập đúng cú pháp hàm my("'+test+'") hoặc kiểm tra element tồn tại');return}
    }else{console.log('lỗi! hãy nhập thêm biểu thức "eq({number})" trong hàm my("'+test+'")');return}
}
else if(/[A-Za-z]/.test(test[0])){
    var index_eq = test.indexOf(' eq(')
var _tag_ = test.slice(0, test.indexOf(' ')).replace(/ /,'').toString()
    if(index_eq>=0){
        for(var i=index_eq+4;i<test.length;i++){
            if(test[i]===')'){break}
             index_ += test[i].toString()
        }
if(document.querySelector(_tag_)==null){console.log('tag "'+_tag_+'" không tồn tại trong DOM');return}
        if(index_==''){console.log('yêu cầu nhập 1 số trong biểu thức eq()');return}
	else{
		
	if(index_child>=0){
 for(var i=index_child+7;i<test.length;i++){
            if(test[i]===')'){break}
             child_index += test[i].toString()
  }
        if(index_child==''){console.log('yêu cầu nhập 1 số trong biểu thức child()');return}
	else{var elm = tag(_tag_)[number(index_)].children[child_index]}
if(elm==null){console.log('lỗi! yêu cầu nhập đúng cú pháp hàm my("'+test+'") hoặc kiểm tra element tồn tại');return}
    }
    
else{var elm = tag(_tag_)[number(index_)]}}
    }else{console.log('lỗi! hãy nhập thêm biểu thức "eq({number})" trong hàm my("'+test+'")');return}
}//đoạn này sao chép ở trên

}
//else if(typeof elm!='object'){console.log('lỗi! my("'+elm+'")');return}


    this.event = function(sk, lenh){elm.addEventListener(sk, lenh)}
    this.removeEvent = function(sh, lenk){elm.removeEventListener(sh, lenk)}
    this.val = function(value_val){if(value_val!=null){elm.value = value_val}else{return elm.value}}
    this.text = function(cnsofjxa){if(cnsofjxa==null){return elm.innerText};elm.innerText = cnsofjxa}
    this.html = function(ncksxow){if(ncksxow==null){return elm.innerHTML};elm.innerHTML = ncksxow}
    this.background = function(back_co){if(back_co==null){return elm.style.background}; elm.style.background = back_co}
    this.color = function(color_co){if(color_co==null){return elm.style.color}; elm.style.color = color_co}
    this.fontSize = function(font_co){if(font_co==null){return elm.style.fontSize}; elm.style.fontSize = font_co}
    this.border = function(border_co){if(border_co==null){return elm.style.border}; elm.style.border = border_co}
    this.borderRadius = function(borderradius_co){if(borderradius_co==null){return elm.style.borderRadius}; elm.style.borderRadius = borderradius_co}
    this.fontFamily = function(fontfamily_co){if(fontfamily_co==null){return elm.style.fontFamily}; elm.style.fontFamily = fontfamily_co}
    this.position = function(position_co){if(position_co==null){return elm.style.position}; elm.style.position = position_co}
    this.marginTop = function(margintop_co){if(margintop_co==null){return elm.style.marginTop}; elm.style.marginTop = margintop_co}
    this.marginLeft = function(marginleft_co){if(marginleft_co==null){return elm.style.marginLeft}; elm.style.marginLeft = marginleft_co}
    this.marginRight = function(marginright_co){if(marginright_co==null){return elm.style.marginRight}; elm.style.marginRight = marginright_co}
    this.marginBottom = function(marginbottom_co){if(marginbottom_co==null){return elm.style.marginBottom}; elm.style.marginBottom = marginbottom_co}
    this.paddingTop = function(paddingtop_co){if(paddingtop_co==null){return elm.style.paddingTop}; elm.style.paddingTop = paddingtop_co}
    this.paddingLeft = function(paddingleft_co){if(paddingleft_co==null){return elm.style.paddingLeft}; elm.style.paddingLeft = paddingleft_co}
    this.paddingRight = function(paddingright_co){if(paddingright_co==null){return elm.style.paddingRight}; elm.style.paddingRight = paddingright_co}
    this.paddingBottom = function(paddingbottom_co){if(paddingbottom_co==null){return elm.style.paddingBottom}; elm.style.paddingBottom = paddingbottom_co}
    this.margin = function(margin_co){if(margin_co==null){return elm.style.margin}; elm.style.margin = margin_co}
    this.padding = function(padding_co){if(padding_co==null){return elm.style.padding}; elm.style.padding = padding_co}
    this.zIndex = function(zindex_co){if(zindex_co==null){return elm.style.zIndex}; elm.style.zIndex = zindex_co}
    this.transform = function(transform_co){if(transform_co==null){return elm.style.transform}; elm.style.transform = transform_co}
    this.transition = function(transition_co){if(transition_co==null){return elm.style.transition}; elm.style.transition = transition_co}
    this.display = function(display_co){if(display_co==null){return elm.style.display}; elm.style.display = display_co}
    this.css = function(tt, giatri){
        if(typeof tt==='object'){
var obj_keys = Object.keys(tt)
var obj_values = Object.values(tt)
var obj_all = Object.entries(tt)
for(var i=0;i<obj_keys.length;i++){
var e = obj_values[i], k = obj_keys[i]
if(e.indexOf('-')>=0 || k.indexOf('-')>=0){elm.style.cssText += k+':'+ e;continue}
eval('elm.style.'+k+'="'+e+'"')
}
        }
	else if(giatri==null){return eval('elm.style.'+tt)}else{if(tt.indexOf('-')>=0){elm.style.cssText += tt+':'+giatri}else{eval('elm.style.'+tt+'="'+giatri+'"')}}
    }
    this.displayToggle = function(){if(elm.style.display=='none'){elm.style.display='block'}else{elm.style.display='none'}}
   this.attr = function(tre, val_tt){
       if(val_tt==null){return elm.getAttribute(tre)}else{
    elm.setAttribute(tre, val_tt)
}
   }
   this.removeAttr = function(tq_sqj){
       if(tq_sqj==null){console.log('yêu cầu bạn nhập vào hàm my().removeAttr() một tham số')}else{elm.removeAttribute(tq_sqj)}
   }
   this.hasAttr = function(jqnd){return elm.hasAttribute(jqnd)}
   this.class = function(jqndd){if(jqndd==null){return elm.className};elm.className=jqndd
   }
   this.me = elm
   this.addClass = function(eckkx){elm.classList.add(eckkx)}
   this.removeClass = function(iwjcv){elm.classList.remove(iwjcv)}
   this.toggleClass = function(kqfck){elm.classList.toggle(kqfck)}
   this.hasClass = function(jcnwoa){return elm.className.indexOf(jcnwoa+'')>=0?true:false}
   this.prop = function(xnswi, cnwid){if(cnwid==null){return eval('elm.'+xnswi)};eval('elm.'+xnswi+'="'+cnwid+'"')}
   this.before = function(mcsox){elm.before(mcsox)}
   this.after = function(nxsoxcj){elm.after(nxsoxch)}
   this.append = function(jxjsk){elm.appendChild(jxjsk)}
   this.prepend = function(cmsmqo){elm.prepend(cmsmqo)}
   this.remove = function(){elm.remove()}
   this.empty = function(){elm.innerHTML = ''}
   this.rotate = function(mfcds){
       if(mfcds==null){if(elm.style.transform.indexOf('rotate')>=0){return tach_so(elm.style.transform).number}else{return 0}}else{elm.style.transform = 'rotate('+mfcds+'deg)'}
   }
   this.fadeIn = function(jcjskvsf,cjakaokcj){if(jcjskvsf==null){elm.style.opacity = 1}else{elm.style.transition = 'opacity '+jcjskvsf/1000+'s linear';elm.style.opacity=1;my(elm).event('transitionend', function(){c(cjakaokcj)})}}
   this.fadeOut = function(cnaoncwo,jcsjaixh){if(cnaoncwo==null){elm.style.opacity = 0}else{elm.style.transition = 'opacity '+cnaoncwo/1000+'s linear';elm.style.opacity=0;my(elm).event('transitionend', function(){c(jcsjaixh)})}}
   this.fadeToggle = function(cmxpanc){
       if(elm.style.opacity==='0'){if(cmxpanc==null){my(elm).fadeIn()}else{my(elm).fadeIn(cmxpanc)}}else{if(cmxpanc==null){my(elm).fadeOut()}else{my(elm).fadeOut(cmxpanc)}}
   }
   this.clone = function(){elm.cloneNode()}
   this.replace = function(jxziqjd){jxziqjd.parentNode.replaceChild(elm,jxziqjd)}
   this.animate = function(fctType, time){
if(time==null){console.log('nhập 1 số vào hàm animate');return}
elm.style.transition = 'all '+time/1000+'s linear'
my(elm).css(fctType)
my(elm).event('transitionend', function(){c()})
}
function c(ggg){ggg;elm.style.transition='none'; my(elm).removeEvent('transitioned', function(){c(ggg)})}//hàm bổ xung dành cho các hàm hiệu ứng
   //prop
   //hasAttribute
   //id
   //class
   //removeAttribute
//getAttribute
     return this
}
//trả về null thì không quan tâm nó k hiện gid mới sợ
//hàm arc cho truyền tham số thứ 7 vào
