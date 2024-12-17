import pandas as pd
from io import StringIO
from datetime import datetime

from pandas import Series

from app.models.return_models import StatisticsReturnModel

async def computestatistics(file: str)-> StatisticsReturnModel:
    df = pd.read_csv(StringIO(file), sep=";")

    beloeb_i_alt: Series = df.beloeb_i_alt

    amount_max: float = beloeb_i_alt.max()
    amount_min: float = beloeb_i_alt.min()
    amount_avg: float = beloeb_i_alt.mean()
    amount_sum: float = beloeb_i_alt.sum()
    amount_count: int = beloeb_i_alt.count()
    amount_std: float = beloeb_i_alt.std()
    amount_median: float = beloeb_i_alt.median()

    return StatisticsReturnModel(
        amount_max=amount_max,
        amount_min=amount_min,
        amount_avg=amount_avg,
        amount_sum=amount_sum,
        amount_count=amount_count,
        amount_std=amount_std,
        amount_median=amount_median
    )
