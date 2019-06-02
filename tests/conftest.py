import json 

from pytest import fixture
from config import Config
from selenium import webdriver


data_path = '../test_data/meddbase.json'

def load_test_data(path):
    with open(path) as data_file:
        data = json.load(data_file)
        return data

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

@fixture(params=load_test_data(data_path))
def test_data(request):
    data = request.param
    return data
