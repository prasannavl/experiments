package main

import (
	"fmt"
	"strconv"
)

func main() {
	v := make([]int, 0, 0)
	c := 1
	l := 1
	for {
		l = len(v)
		if cap(v) != c {
			c = cap(v)
			fmt.Printf("%v %v\n", l, sizeString(c))
		}
		v = append(v, 0)
	}
}

var sizeSuffixes = [...]string{"b", "kb", "mb", "gb"}

func sizeString(size int) string {
	index := 0
	i := 1000
	for ; size > i; i *= 1000 {
		index++
	}
	maxLen := len(sizeSuffixes)
	if index >= maxLen {
		size = maxLen - 1
	}
	n := float64(size) / float64(i/1000)
	s := strconv.FormatFloat(n, 'f', 2, 64)
	return s + sizeSuffixes[index]
}
