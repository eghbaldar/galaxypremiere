$(document).ready(function () {
    var tabcontent;
    tabcontent = document.getElementsByClassName("TabcontentClass");
    for (i = 0; i < tabcontent.length; i++) {
        if (tabcontent[i].className == "TabcontentClass active") {
            document.getElementById(tabcontent[i].id).style.display = "block";
        }
    }
});
function tabNavigation(evt, tabName) {

    // Declare all variables
    var i, tabcontent, tablinks;

    // Get all elements with class="tabcontent" and hide them
    tabcontent = document.getElementsByClassName("TabcontentClass");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    // Get all elements with class="tablinks" and remove the class "active"
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }

    // Show the current tab, and add an "active" class to the button that opened the tab
    document.getElementById(tabName).style.display = "block";
    //alert(evt.currentTarget.className);
    evt.currentTarget.className += " active";
}

function tabNavigationByTabName(tabName, indexPage) {
    // developed by the King [blog.eghbaldar.ir]
    var i, tabcontent, tablinks;

    tabcontent = $("body").find(".TabcontentClass");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    tablinks = $("body").find(".tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }
    document.getElementById(tabName).style.display = "block";
    tablinks[indexPage].className += " active";
}