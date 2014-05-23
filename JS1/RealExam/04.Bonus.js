function b(a){return a[0]>0?a[1]>0?1:3:a[1]<0?2:0;}

(function () {
    console.log(b(['-1', '-2']));
    console.log(b(['1', '-2']));
    console.log(b(['-1', '2']));
    console.log(b(['1', '2']));
})();