/** @type {import('tailwindcss').Config} */
export default {
        content: ["./index.html", "./src/**/*.{js,ts,jsx,tsx}"],
        theme: {
                extend: {
                        fontFamily: {
                                sans: "Roboto Mono, monospace",
                        },
                        fontSize: {
                                huge: ["80  rem", { lineHeight: "1" }],
                        },
                        height: {
                                screen: "100dvh",
                        },
                },
        },
        plugins: [],
};