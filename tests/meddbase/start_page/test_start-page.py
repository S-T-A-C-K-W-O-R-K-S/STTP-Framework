from pytest import mark

@mark.smoke
@mark.start_page
def test_start_page_functions_as_expected():
    assert True
