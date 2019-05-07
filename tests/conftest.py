from pytest import fixture
from config import Config


def pytest_addoption(parser):
    parser.addoption("--env", action="store", help="environment to run tests against")


@fixture(scope="session")
def env(request):
    return request.config.getoption("--env")


@fixture(scope="session")
def custom_config(env):
    cfg = Config(env)
    return cfg
