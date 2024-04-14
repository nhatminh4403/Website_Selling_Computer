// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/*document.getElementById('searchform-product').addEventListener('submit', function (event) {
    event.preventDefault(); // ngăn chặn hành vi mặc định của form

    var inputSearch = document.getElementById('inputSearchAuto');
    var searchQuery = inputSearch.value; // lấy giá trị từ input

    // tạo yêu cầu AJAX
    var xhr = new XMLHttpRequest();
    xhr.open('GET', '/search?type=product&q=' + encodeURIComponent(searchQuery), true);
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            // khi nhận được kết quả, hiển thị nó trong #ajaxSearchResults
            document.getElementById('ajaxSearchResults').style.display = 'block';
            document.querySelector('.resultsContent').innerHTML = xhr.responseText;
        }
    }
    xhr.send();
});*/