from pytest import mark

@mark.smoke
@mark.start_page
def test_start_page():
    assert True
