$(function () {
    $('#sortable').sortable({
        tolerance: 'touch',
        drop: function ()
        {
            alert('delete!');
        },
        update: function ()
        {
            console.log("Hellow world")
        },
    });
});