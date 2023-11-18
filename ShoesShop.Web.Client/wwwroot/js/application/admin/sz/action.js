(function ($) {
    'use strict';

    var onViewDetail = function () {
        $('.btn-view-detail').on('click', function (e) {
            e.preventDefault();
            var id = $(this).attr('data-id')
            coreAjaxGetPartialView(true, '/Admin/Size/DetailPartial?id=' + id, null, function (response) {
                $("#modal-body").html(response);
                $('#modal-popup').modal('show');
            }, function () {
            });
        });
    }

    var onDelete = function () {
        $('.btn-delete').on('click', function (e) {
            e.preventDefault();
            var id = $(this).attr('data-id')
            sweetAlertDeleteConfirmation('/Admin/Size/Delete', id, $('#TitleDelete').val(), $('#TextDelete').val(),
                function () { getListSize() })
        });
    }

    var onUpdate = function () {
        $('.btn-edit').on('click', function (e) {
            e.preventDefault();
            var id = $(this).attr('data-id')
            coreAjaxGetPartialView(true, '/Admin/Size/UpdatePartial?id=' + id, null, function (response) {
                $("#modal-body").html(response);
                $('#modal-popup').modal('show');
            }, function () {
            });
        });
    }

    //Load functions
    $(document).ready(function () {
        onViewDetail();
        onDelete();
        onUpdate();
    });
})(jQuery);