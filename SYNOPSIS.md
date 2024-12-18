# System Integration Synopsis

### Content

- Motivation
- Theory
- Practice
- Discussion

## Motivation

Python has a large adoption amongst data scientist, and offers a toolbox ready to use for crunching numbers.
Over time, it has become easyer to source skilled labour, regarding the development of computational software.
In this solution the surface is barely scratched, but if it was to be extended with additional functionality, it would be a rather trivial task to just hook into code, written by people who are better at math than myself.

Dotnet is available on most platforms these days, and offers a toolset that makes it easy to develop a lot of functionality, within a limited time frame. It is also rather performant (especially compared to python), and for trivial tasks like this, it is easy to find skilled enough engineers

## Theory

### FastAPI

FastAPI is a popular (and fast) web framework for Python. It uses Python type annotation which makes it easy to work with in modern software IDE's.
When communicating data back and forth it uses Pydantic models, which name might insinuate that it is quite pedantic. What seems like limitations in the freedom of how you can code python, gives us the desired speed

### Pandas

Pandas is a library used for data-analysis and manipulation. Underneath the hood it is build in C, which makes it quite fast.

In this project I make use if DataFrames and Series.
The entire CSV-file is converted into a DataFrame, and each column is a Series

### C#
After releasing dotnetcore, C# has been available on most platforms. The integrated tooling makes it very fast to develop in, and with it's frequent relase cycle, optimizations hits the end users fast. 


### Applied theory
#### async/await
All methods communicate asynchronously with each other, to reduce response time.

#### Dependency injection
Where needed, dependencies are injected

## Practice



## Discussion

- Yay...discuss!!!
