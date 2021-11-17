<script type="text/javascript">
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
        alert("Yorumuz gönderildi");
    Makaleler();
},
            error: function () {
        alert("Yorum yaparken hata oluştu");
    }
});
});
</script>