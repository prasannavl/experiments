fn main() {
    let mut v = vec![0;0];

    let mut cap = 1;
    let mut len = 1;
    
    loop {        
        len = v.len();

        if v.capacity() != cap {
            cap = v.capacity();
            println!("{} {}", len, size_string(cap));
        }

        v.push(0);
    }
}

fn size_string(size: usize) -> String {
    let size_suffixes = ["b", "kb", "mb", "gb"];
    let mut index = 0;
    let mut i = 1000;

    while size > i {
        index += 1;
        i *= 1000;
    }

    let max_len = size_suffixes.len();
    if index > max_len {
        index = max_len;
    }

    let f = size as f32 / (i / 1000) as f32;
    return format!("{:.2}{}", f, size_suffixes[index]);
}

#[cfg(test)]
mod tests {}
