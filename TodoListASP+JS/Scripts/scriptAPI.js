function addNewTodo(name) {
    $.post("/api/data?todo=" + name, function (data) {
        getAllList();
    });
}

function getTodoById(current_index) {
    $.get("/api/data?id=" + current_index, function (data) {
        $('#name-todo').val(data);
    });
}

function replaceTodo(current_index, name) {
    $.get("/api/data?id=" + current_index, function (data) {
        $.post("/api/data?oldTodo=" + data + "&newTodo=" + name, function () {
            getAllList();
        });
    });
}

function deleteTodo(current_index) {
    $.get("/api/data?id=" + current_index, function (data) {
        $.get("/api/data?todo=" + data, function () {
            getAllList();
            getTodoById(current_index);
        });
    });
    
}

function removeUp(current_index) {
    $.get("/api/data?id=" + current_index, function (data) {
        $.get("/api/data?todo=" + data + "&direction=false", function () {
            getAllList();
        });
    });
}

function removeDown(current_index) {
    $.get("/api/data?id=" + current_index, function (data) {
        $.get("/api/data?todo=" + data + "&direction=true", function () {
            getAllList();
        });
    });
}

function getAllList() {
    $.get("/api/data", function (data) {
        fillUL(data);
    });
}