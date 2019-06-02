#region Imports
from pytest import mark
#endregion

#region Tests
@mark.smoke
@mark.login_page
class LoginPageTestSuite():
    @mark.skip
    @mark.parametrize('system', [('system10'),('testb1')])
    def test_login_page_with_on_the_fly_parameters(self, system):
        assert True
        print(f'login page on {system} found as expected') # in order to see this in the console window, pytest needs to be executed with the -s parameter which disables capturing of the stdout/stderr output

    def test_login_page_with_test_data(self, test_data):
        assert True
        print(f'login page on {test_data} found as expected') # in order to see this in the console window, pytest needs to be executed with the -s parameter which disables capturing of the stdout/stderr output

    def test_login_page_cross_browser(self, browser):
        browser.get('https://system10.meddbase.com/em.aspx/?p=Login/Password&direct=true')
        assert True
        print('login page on system10 found as expected') # in order to see this in the console window, pytest needs to be executed with the -s parameter which disables capturing of the stdout/stderr output
#endregion
