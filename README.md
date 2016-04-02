#########################################################################

    Image Factory
    Image processing app + cooccurrence matrix utility
    -----------------------------------------------------------------
    
    Author      : Romain Vinders
    Languages   : C#, OpenGL with SharpGL
    Date        : 2015
    License     : GPLv2

#########################################################################

Image Factory - image processing:
- image cropping and image resampling (nearest neighbor, bilinear)
- color palette management, color replacement (pipette with tolerance setting)
- color filters (extract plane, negative, compensated grayscale, ...)
- convolution filters (mean, gaussian, median, high-pass, unsharp-masking, ...)
- edge-detection (Sobel, Prewitt, Laplace, Kirsch, Roberts) + masking
- morphology filters (erosion, dilatation, opening, closing, multiple, neighborhoods)
- display histogram, equalization, auto-normalize, normalize manually (slider)
- single/multi-threshold: auto (Otsu), manual (slider(s))

Cooccurrence matrix 3D display:
- calculate gray-level cooccurrence matrix
- settings: distance, direction, order, symmetry
- display the result in a 3D viewport with information
- show stats about the GLCM + 2D view
