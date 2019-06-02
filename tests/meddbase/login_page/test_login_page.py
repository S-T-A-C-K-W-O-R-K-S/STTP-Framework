from pytest import mark


@mark.smoke
@mark.login_page
@mark.parametrize('system', [
        ('system10'),
        ('testb1')
    ]
)
@mark.skip
def test_login_page_with_on_the_fly_parameters(system):
    assert True
    print(f'login page on {system} found as expected') # in order to see this in the console window, pytest needs to be executed with the -s parameter which disables capturing of the stdout/stderr output

@mark.smoke
@mark.login_page
def test_login_page_cross_browser(browser):
    browser.get('https://system10.meddbase.com/em.aspx/?p=Login/Password&direct=true')
    assert True
    print('login page on system10 found as expected')
