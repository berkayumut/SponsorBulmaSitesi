(function () {
    var options = {
        whatsapp: "+905530843224",
        call_to_action: "Merhaba, Nasıl yardımcı olabilirim?",
        position: "left",
    };
    var proto = document.location.protocol, host = "whatshelp.io", url = proto + "//static." + host;
    var s = document.createElement('script'); s.type = 'text/javascript'; s.async = true; s.src = url + '/widget-send-button/js/init.js';
    s.onload = function () { WhWidgetSendButton.init(host, proto, options); };
    var x = document.getElementsByTagName('script')[0]; x.parentNode.insertBefore(s, x);
})();

$(document).on("click", "#yorumyap", function () {
    var veriler = {
        isim: $("#isim").val(),
        mail: $("#mail").val(),
        yorum: $("#yorum").val()
    };

    $.ajax({
        type: 'POST',
        url: '/Uye/YorumYap',
        data: JSON.stringify(veriler),
        dataType: "JSON",
        contentType: "application/json;charset=utf-8",
        success: function (gelenDeg) {
            alert("Yorumuz gönderildi. Onaylandıktan sonra yayınlanacaktır.");
            $("#isim").val("");
            $("#mail").val("");
            $("#yorum").val("");

        },
        error: function () {
            alert("Yorum yaparken hata oluştu");
        }
    });
});
$(document).on("click", "#aramayap", function () {
    var veriler = {
        kod: $("#islemkodu").val()
    };
    $.ajax({
        type: 'POST',
        url: '/Uye/IslemTakip',
        data: JSON.stringify(veriler),
        dataType: "JSON",
        contentType: "application/json;charset=utf-8",
        success: function (gelenDeg) {
            if (gelenDeg == "hata") {
                alert("hata oluştu");
                var url = "/cekilisevim/";
                window.location.href = url;
            }
            else if (gelenDeg == "Yok") {
                alert("İşlem Bulunamadı");
                var url = "/cekilisevim/";
                window.location.href = url;
            }
            else {
                var url = "/talep-islemim/" + gelenDeg;
                window.location.href = url;
            }

        },
        error: function () {
            alert("Yorum yaparken hata oluştu");
        }
    });
});
