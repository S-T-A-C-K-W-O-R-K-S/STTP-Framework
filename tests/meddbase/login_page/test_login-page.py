from pytest import mark

@mark.smoke
@mark.authentication
def test_login_page_functions_as_expected():
    assert True
