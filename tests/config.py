#region Configuration
class Config:
    def __init__(self, env):
        supported_envs = ["dev", "stg", "prod"]

        if env.lower() not in supported_envs:
            raise Exception(f'"{env}" is not a supported environment.' + '\n' + f'Supported Environments: {supported_envs}')

        self.base_url = {
            "dev": "https://testlogin.meddbase.com/",
            "stg": "https://rc.meddbase.com/",
            "prod": "https://system.meddbase.com/",
        }[env]

        self.base_url_direct = {
            "dev": "https://testb1.meddbase.com/em.aspx/?p=Login/Password&direct=True",
            "stg": "https://rc.meddbase.com/em.aspx/?p=Login/Password&direct=True",
            "prod": "https://system10.meddbase.com/em.aspx/?p=Login/Password&direct=True",
        }[env]
#endregion
