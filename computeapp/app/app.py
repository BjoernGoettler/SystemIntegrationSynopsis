from fastapi import FastAPI, UploadFile
from app.models.return_models import StatisticsReturnModel
from app.repository.compute import computestatistics
app = FastAPI()

@app.post("/")
async def uploadfile(file: UploadFile)-> StatisticsReturnModel:
    contents = await file.read()
    return await computestatistics(contents.decode("utf-8"))