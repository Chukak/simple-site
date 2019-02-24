/* */
function clickOnIcon()
{
    $(this).addClass('d-none').prevAll('#NewUsernameInput').val('');
}

function addIcon()
{
    if ($(this).val().length > 0) {
        $(this).nextAll('.form-clear-icon').removeClass('d-none');
    }
}

function removeIcon()
{
    if ($(this).val().length === 0) {
        $(this).nextAll('.form-clear-icon').addClass('d-none');
    }
}

function clearInputScript()
{
    $('#NewUsernameInput').on('keydown focus', addIcon).on('keydown keyup blur', removeIcon);
    $('.form-clear-icon').on('click', clickOnIcon);
}


clearInputScript();
