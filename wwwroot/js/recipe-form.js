$(document).ready(function () {
    $('#ImageFile').on('change', function () {
        var file = this.files[0];
        if (file) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('.cover-preview').removeClass('d-none').attr('src', e.target.result);
            }
            reader.readAsDataURL(file);
        } else {
            // Reset the preview if no file is selected
            $('.cover-preview').addClass('d-none').attr('src', '');
        }
    });
});