from pytest import fixture
from config import Config
from selenium import webdriver


def pytest_addoption(parser):
    parser.addoption("--env", action="store", help="environment to run tests against")


@fixture(scope="session")
def env(request):
    return request.config.getoption("--env")


@fixture(scope="session")
def custom_config(env):
    cfg = Config(env)
    return cfg

@fixture(params=[webdriver.Chrome, webdriver.Firefox])
def browser(request):
    driver = request.param
    driver_instance = driver()
    yield driver_instance
    driver_instance.quit()
