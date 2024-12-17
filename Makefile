INPUT = SYNOPSIS.md
OUTPUT = synopsis.pdf
PANDOC = pandoc


all: $(OUTPUT)

$(OUTPUT): $(INPUT)
	$(PANDOC) $(INPUT) -o $(OUTPUT)

clean:
	rm -f $(OUTPUT)

help:
	@echo "Usage:"
	@echo "  make           Generate the PDF from the README.md file."
	@echo "  make clean     Remove the generated PDF."
	@echo "  make help      Show this help message."
    
.PHONY: all clean help pycache