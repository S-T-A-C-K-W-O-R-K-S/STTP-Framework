#region Imports
from pytest import mark
#endregion

#region Framework Unit Tests
@mark.debug
class DebugTestSuite:
    def test_environment_is_dev(self, custom_config):
        base_url = custom_config.base_url
        base_url_direct = custom_config.base_url_direct
        assert base_url == "https://testlogin.meddbase.com/"
        assert base_url_direct == "https://testb1.meddbase.com/em.aspx/?p=Login/Password&direct=True"

    @mark.skip(reason="currently not automating on the staging environment")
    def test_environment_is_stg(self, custom_config):
        base_url = custom_config.base_url
        base_url_direct = custom_config.base_url_direct
        assert base_url == "https://rc.meddbase.com/"
        assert base_url_direct == "https://rc.meddbase.com/em.aspx/?p=Login/Password&direct=True"

    @mark.skip(reason="currently not automating on the production environment")
    def test_environment_is_prod(self, custom_config):
        base_url = custom_config.base_url
        base_url_direct = custom_config.base_url_direct
        assert base_url == "https://system.meddbase.com/"
        assert base_url_direct == "https://system10.meddbase.com/em.aspx/?p=Login/Password&direct=True"
#endregion
