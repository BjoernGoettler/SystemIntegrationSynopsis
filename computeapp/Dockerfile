FROM ghcr.io/astral-sh/uv:python3.12-bookworm-slim
ENV UV_COMPILE_BYTECODE=1 UV_LINK_MODE=copy
WORKDIR /app

ADD app .
COPY requirements.txt .

RUN uv venv
RUN uv pip install -r requirements.txt

ENV PATH="/app/.venv/bin:$PATH"
CMD ["fastapi", "run", "app.py"]
