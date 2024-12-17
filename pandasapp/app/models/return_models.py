from datetime import datetime

from pydantic import BaseModel

class StatisticsReturnModel(BaseModel):
    amount_max: float
    amount_min: float
    amount_avg: float
    amount_sum: float
    amount_count: int
    amount_std: float
    amount_median: float

