// The Process Indicator we use to that operation can take a noticable amount of time.
const ProcessIndicator = '<img width="40" height="40" src="/images/rollingwheel.gif">';

//  
function formatDate(date) {
    return moment(date).locale(cultureInfo).format('L');
}

//
function formatDateTime(date) {
    var options = { year: 'numeric', month: '2-digit', day: '2-digit', hour: '2-digit', minute: '2-digit', second: '2-digit' };
    return new Date(date).toLocaleDateString(cultureInfo, options);
}

// It could be rewrited to support filters on tables without srverside
function AssignSearchEventsOnTableSelectClientSide(tab, idx) {
    $('select', tab.column(idx).header()).on('change', function () {

        if (this.value !== "") {
            var text = this.options[this.selectedIndex].text;
            var val = $.fn.dataTable.util.escapeRegex(text);
            tab.columns(idx).search(val ? '^' + val + '$' : '', true, false).draw();
        }
        else
            tab.column(idx)
                .search(this.value)
                .draw();
    });
    $('select', tab.column(idx).header()).on('click', function (e) {
        e.stopPropagation();
    });
}


// The function bounds a datatable column and input or select element to support search by particular data column.
// The html element must have a data-column attribute with number of the data column.
function AssignSearchEvents(tab, ctrl) {
    var idx = $(ctrl).data('column');
    $(ctrl).on('change', function () {
        //var s = $(ctrl).val();
        tab.column(idx)
            .search(this.value)
            .draw();
    });
    $($(ctrl), tab.column(idx).header()).on('click', function (e) {
        e.stopPropagation();
    });

    //$(ctrl).on('change', function () {
    //    tab.column(idx)
    //        .search(this.value)
    //        .draw();
    //});
    //$('select', tab.column(idx).header()).on('click', function (e) {
    //    e.stopPropagation();
    //});
}

