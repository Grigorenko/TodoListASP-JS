getAllList();

function fillUL(todos) {
    $('.todoId').remove();
    for (var i = 0; i < todos.length; i++) {
        $('<li class="todoId" id="todo_' + i + '">' + todos[i] + '</li>').appendTo('.todos');
    }
}


$('body').on('click', '#btn-add', function (e) {
    var name = $('#name-todo').val();
    $('#name-todo').val('');

    addNewTodo(name);
});

var current_index;
$('body').on('click', '.todoId', function (e) {
    $('#toolbar').css('display', "block");
    console.log(e);
    var current_name = e.target.id;
    current_index = current_name.substr(current_name.indexOf('_') + 1);
    
    getTodoById(current_index);
});


$('body').on('click', '#btn-save', function (e) {
    var name = $('#name-todo').val();
    $('#toolbar').css('display', "none");
    $('#name-todo').val('');

    replaceTodo(current_index, name);
});

$('body').on('click', '#btn-delete', function (e) {
    $('#toolbar').css('display', "none");
    $('#name-todo').val('');

    deleteTodo(current_index);
});


$('body').on('click', '#btn-up', function (e) {
    if (current_index > 0) {
        removeUp(current_index);
        current_index--;
    }
});


$('body').on('click', '#btn-down', function (e) {
    $.get("/api/data", function (data) {
        var count = data.length;

        if (current_index < count - 1) {
            removeDown(current_index);
            current_index++;
        }
    })
});

