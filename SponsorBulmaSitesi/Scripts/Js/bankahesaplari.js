    $(function() {    
        $('#input-search').on('keyup', function() {
          var rex = new RegExp($(this).val(), 'i');
            $('.itemss').hide();
            $('.itemss').filter(function() {
                return rex.test($(this).text());
            }).show();
        });
    });