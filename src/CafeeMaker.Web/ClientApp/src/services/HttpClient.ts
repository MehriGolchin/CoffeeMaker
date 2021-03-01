export async function post<T>(url: URL, body: object) : Promise<T> {
    const response = await fetch(url.toString(), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(body)
    });
    if (!response.ok) throw new Error(response.statusText);
    return await response.json();
}

export async function get<T>(url: URL): Promise<T> {
    const response = await fetch(url.toString());
    if (!response.ok) throw new Error(response.statusText);
    return await response.json();
}