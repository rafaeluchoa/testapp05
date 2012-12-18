$.ajaxSetup({
    cache: false
});

function CallAjaxBind(id, url, updateId, builder) {

    var data = $(id).closest('form').serialize();

    $.ajax({
        headers: { "X-Requested-With": "XMLHttpRequest" },
        type: "POST",
        url: url,
        data: data,
        success: function (result, textStatus, jqXHR) {

            var contentType = jqXHR.getResponseHeader("Content-Type");
            var jsonContent = contentType.indexOf("application/json") > -1;
            var htmlContent = contentType.indexOf("text/html") > -1;

            if (jsonContent) {

                Bind(result, updateId, builder);

            } else if (htmlContent) {

                $(updateId).replaceWith(result);
                
            }
        }
    });

}

function Bind(result, updateId, builder) {

    if (result.html) {
        $(updateId).replaceWith(result.html);
    }

    $('.validation-message').each(function (index, value) {
        $(value).empty();
    });

    $('.required').each(function (index, value) {
        $(value).toggleClass('required', false);
    });
    
    if (result.validations) {
        $.each(result.validations, function (index0, validation) {

            var validationMessage = $("#" + validation.Key + "-validation-message");

            var messages = "";
            $.each(validation.Value, function (index1, message) {
                messages += '<div>' + message + '</div>';
            });

            validationMessage.html(messages);

            $("#" + validation.Key).toggleClass('required', true);

        });
    }

    if (result.script) {
        $(updateId).append('<script>' + result.script + '</script>');
    }

    if (result.binders) {
        $.each(result.binders, function(index) {
            var input = $(this)[index];
            $("#" + input.Key).val(input.Value);
        });
    }
}
