$(function () {

    var ajaxFormSubmit = function () {
        var $form = $(this);
        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()

        };

        //https://api.jquery.com/jQuery.ajax/
        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-mra-target"));
            var $newHtml = $(data);
            
            $target.replaceWith($newHtml);
            $newHtml.effect("highlight");

        });
        return false;
    };

    var submitAutoCompleteForm = function (event, ui) {

        var $input = $(this);
        $input.val(ui.item.label);

        var $form = $input.parents("form:first");
        $form.submit();

    }

    var createAutocomplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-mra-autocomplete"),
            select: submitAutoCompleteForm,
            minLength: 2,
        };

        $input.autocomplete(options);

    }


    $("form[data-mra-ajax='true']").submit(ajaxFormSubmit);
    //https://api.jquery.com/submit/
    //Bind an event handler to the "submit" JavaScript event, or trigger that event on an element

    $("input[data-mra-autocomplete]").each(createAutocomplete);

});