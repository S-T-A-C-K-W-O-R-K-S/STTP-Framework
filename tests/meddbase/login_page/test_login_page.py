from pytest import mark

@mark.smoke
@mark.login_page
def test_login_page():
    assert True
