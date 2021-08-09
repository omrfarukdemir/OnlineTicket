// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function setAutoComplete(id, url, valueElId) {
    $(`#${id}`).autocomplete({
        serviceUrl: url,
        onSelect: function (suggestion) {
            $(`#${valueElId}`).val(suggestion.data);
        },
        minChars: 0
    });
}

function setDateRangePicker(id, setDate,date) {
    
    $(`#${id}`).daterangepicker({
        singleDatePicker: true,
        minDate: moment(),
        autoUpdateInput: false
    }, function (chosenDate) {
        $(`#${id}`).val(chosenDate.format('YYYY-MM-DD'));
    });

    if (setDate) {
        $(`#${id}`).val(date);
    }
}