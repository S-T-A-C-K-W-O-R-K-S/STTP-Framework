from pytest import mark


@mark.smoke
@mark.admin
@mark.configuration
class ChamberConfigurationTestSuite:
    @mark.chargeable_features
    def test_admin_configuration_chargeable_features(self):
        assert True

    @mark.patient_portal
    @mark.oh_portal
    def test_admin_configuration_online_portals(self):
        assert True

    @mark.advanced_configuration
    def test_admin_configuration_advanced(self):
        assert True
