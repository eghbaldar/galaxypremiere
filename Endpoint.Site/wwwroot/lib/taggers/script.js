var mySellect = sellect("#my-element", {
    originList: ['banana', 'apple', 'pineapple', 'papaya', 'grape', 'orange', 'grapefruit', 'guava', 'watermelon', 'melon'],
    destinationList: ['banana', 'papaya', 'grape', 'orange', 'guava'],
    onInsert: updateDemoLists,
    onRemove: updateDemoLists
});

mySellect.init();

// demo code to return lists
function updateDemoLists(event, item) {
    //var selectedList = document.getElementById('selected-list');
    //var unselectedList = document.getElementById('unselected-list');
    var selectedArr;
    var unselectedArr;

    //while (selectedList.firstChild) {
    //    selectedList.removeChild(selectedList.firstChild);
    //}

    //while (unselectedList.firstChild) {
    //    unselectedList.removeChild(unselectedList.firstChild);
    //}

    selectedArr = mySellect.getSelected();
    unselectedArr = mySellect.getUnselected();

    //selectedArr.forEach(function (item, index, arr) {
    //    var span = document.createElement('span');
    //    span.innerText = item;
    //    selectedList.appendChild(span);
    //});

    unselectedArr.forEach(function (item, index, arr) {
        var span = document.createElement('span');
        span.innerText = item;
        //unselectedList.appendChild(span);
    });
}