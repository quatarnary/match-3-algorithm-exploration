init

example board
|r c| 0 | 1 | 2 | 3 | 4 |
|---|---|---|---|---|---|
| 0 | B | R | Y | B | B |
| 1 | Y | R | G | G | R |
| 2 | G | G | B | R | Y |
| 3 | Y | Y | R | B | R |
| 4 | B | R | B | G | B |

## or instead of Bitmask approach let's go with 2D array with floating point storage...

1 for vertical, .1 for horizontal
- the existing color is 1.1
- for each vertical same consecutive color +1
- for each horizontal same consecutive color +.1

for blue example float storage 
|r c|  0  |  1  |  2  |  3  |  4  |
|---|-----|-----|-----|-----|-----|
| 0 | 1.1 | 0.0 | 0.0 | 1.2 | 1.1 |
| 1 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 |
| 2 | 0.0 | 0.0 | 1.1 | 0.0 | 0.0 |
| 3 | 0.0 | 0.0 | 0.0 | 1.1 | 0.0 |
| 4 | 1.1 | 0.0 | 1.1 | 0.0 | 1.1 |

for green example float storage 
|r c|  0  |  1  |  2  |  3  |  4  |
|---|-----|-----|-----|-----|-----|
| 0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 |
| 1 | 0.0 | 0.0 | 1.2 | 1.1 | 0.0 |
| 2 | 1.2 | 1.1 | 0.0 | 0.0 | 0.0 |
| 3 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 |
| 4 | 0.0 | 0.0 | 0.0 | 1.1 | 0.0 |

### now the questions are...
-  how to detect T, L square matches?
-  how to highlight a possible move?

for template example float storage 
|r c|  0  |  1  |  2  |  3  |  4  |
|---|-----|-----|-----|-----|-----|
| 0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 |
| 1 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 |
| 2 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 |
| 3 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 |
| 4 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 |

## Bitmask approach

Example Board Bitmask:
|r c| 0    | 1    | 2    | 3    | 4    |
|---|------|------|------|------|------|
| 0 | 0001 | 0010 | 0100 | 0001 | 0001 |
| 1 | 0100 | 0010 | 1000 | 1000 | 0010 |
| 2 | 1000 | 1000 | 0001 | 0010 | 0100 |
| 3 | 0100 | 0100 | 0010 | 0001 | 0010 |
| 4 | 0001 | 0010 | 0001 | 1000 | 0001 |

```
int wholeGrid = 0b 0001 0010 0100 0001 0001 0100 0010 1000 1000 0010 1000 1000 0001 0010 0100 0100 0100 0010 0001 0010 0001 0010 0001 1000 0001
```

I know this is not how it should look but gotta start from somewhere

Example Match Patterns:

horizontal 3:
| b | b | b | b | b |
|---|---|---|---|---|
| 1 | 1 | 1 | 0 | 0 |

T shape:
| b | b | b |
|---|---|---|
| 1 | 1 | 1 |
| 0 | 1 | 0 |
| 0 | 1 | 0 |
