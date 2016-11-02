
var todos = ['first','second', 'third', 'fourth'];

$('#list-todo').append('<ul class="todos"></ul>');

function fillUL() {
    
    $('.todoId').remove();
    for (var i = 0; i < todos.length; i++) {
        $('<li class="todoId" id="todo_' + i + '">' + todos[i] + '</li>').appendTo('.todos');
    }
}

fillUL();

$('body').on('click', '#btn-add', function (e) {
    var name = $('#name-todo').val();
    todos.push(name);
    $('#name-todo').val('');
    fillUL();
});

var current_index;
$('body').on('click', '.todoId', function (e) {
    $('#toolbar').css('display', "block");
    var temp = e.target.id;
    current_index = temp.substr(temp.indexOf('_') + 1);
    $('#name-todo').val(todos[current_index]);
});


$('body').on('click', '#btn-save', function (e) {
    var name = $('#name-todo').val();
    todos[current_index] = name;
    complete();
});

$('body').on('click', '#btn-delete', function (e) {
    todos.splice(current_index, 1);
    complete();
});

function complete() {
    $('#toolbar').css('display', "none");
    $('#name-todo').val('');
    fillUL();
}


$('body').on('click', '#btn-up', function (e) {
    if (current_index > 0) {
        this_todo = todos[current_index];
        todos.splice(current_index, 1);
        todos.splice(current_index - 1, 0, this_todo);
        current_index--;

        fillUL(); 
    }
});



$('body').on('click', '#btn-down', function (e) {
    if (current_index < todos.length -1) {
        this_todo = todos[current_index];
        
        var yt = Number(current_index) + 1;
        todos.splice(current_index, 1);
        todos.splice(yt, 0, this_todo);
        
        current_index++;

        fillUL();
    }
});
