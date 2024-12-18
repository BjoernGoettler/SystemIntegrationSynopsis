INPUT = SYNOPSIS.md
OUTPUT = synopsis.pdf
PANDOC = pandoc
PLANTUML = ~/.plantuml/plantuml-1.2024.7.jar

all: $(OUTPUT)

$(OUTPUT): $(INPUT)
	$(PANDOC) $(INPUT) -o $(OUTPUT)

clean:
	rm -f $(OUTPUT)

diagrams:
	java -Dapple.awt.UIElement=true -jar $(PLANTUML) -o diagrams ./documentation/*.puml

help:
	@echo "Usage:"
	@echo "  make           Generate the PDF from the README.md file."
	@echo "  make clean     Remove the generated PDF."
	@echo "  make help      Show this help message."
    
.PHONY: all clean help pycache diagrams