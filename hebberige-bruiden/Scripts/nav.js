
var state = false
function toggleMenu()
{
    var menu = document.getElementById("collapsed-menu-items");

    if (state)
    {
        menu.style.display = "none";
    }
    else
    {
        menu.style.display = "block";

    }

    state = !state;
}