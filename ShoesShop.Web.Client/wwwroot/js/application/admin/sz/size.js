(function ($) {
    'use strict';

    var addNew = function () {
        $('#btn-add-new').on('click', function (e) {
            e.preventDefault();
            coreAjaxGetPartialView(true, '/Admin/Size/AddNewPartial', null, function (response) {
                $("#modal-body").html(response);
                $('#modal-popup').modal('show');
            }, function () {
            });
        });
    }

    //Load functions
    $(document).ready(function () {
        getListSize();
        addNew();
    });
})(jQuery);