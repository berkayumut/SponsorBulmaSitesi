scrollTableColumnWidth();

// Window resize.
$(window).resize(function () {
    scrollTableColumnWidth();
});

/*
 * This function will set heading cells width equal to its coresponding table column width
 * for all tables with the 'scrollTable' class.
 */
function scrollTableColumnWidth() {
    let cell,
        tableArr = document.getElementsByClassName('scrollTable'),
        tableBodyWidth,
        tableHeadingCellArr,
        totalWidth;

    // Loop through all scrollable tables and correct the th widths.
    for (let tableIndex = 0; tableIndex < tableArr.length; tableIndex++) {
        tableHeadingCellArr = [];
        totalWidth = 0;

        // Get heading cells for current table.
        $(tableArr[tableIndex]).find('th').each(function (i, el) {
            tableHeadingCellArr.push(this);
        });

        // Set heading cell width for all heading cells in table except last.
        for (let i = 0; i < tableHeadingCellArr.length - 1; i++) {
            cell = $(tableArr[tableIndex]).find('tr:last').find('td').eq(i);

            $(tableHeadingCellArr[i]).outerWidth($(cell).outerWidth(true));
            totalWidth += $(cell).outerWidth(true);
        }

        /*
         * Set last table heading cell width equal to remaining width
         * (table body width - sum of rest heading cells), this will 'house' the scrollbar.
         */
        tableBodyWidth = $(tableArr[tableIndex]).find('tbody').outerWidth(true);
        $(tableHeadingCellArr[tableHeadingCellArr.length - 1]).outerWidth(tableBodyWidth - totalWidth);
    }
}