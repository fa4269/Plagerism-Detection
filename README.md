# Plagerism-Detection

Corpus: https://ir.shef.ac.uk/cloughie/resources/plagiarism_corpus.html
Original Text: To be made

Language: C#

Application will take two files as input, a corpus of documents to be tested for plagerism and a document containing the original text.

User can choose between 3 algoriths to test these documents for plagerism.
1. Knuth-Morris-Pratt (KMP) Algorithm
2. Longest Common Sub-sequence (LCSS) Algorithm
3. Rabin-Karp fingerprints

Application will output a list of documents that exceed the plagerism threshold.

Each algorith will read through the corpus.zip file extract one document, and then test that document using the selected algorithm against the original document. Once a corpus doc has finished the application will use the next document in the corpus, this will continue until all documents in the corpus have been scanned. Once this process is finished a list of documents and their plagerism percentage will be output in the command prompt.
