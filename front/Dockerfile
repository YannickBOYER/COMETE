# Create a dockerfile for an Angular application
# Use the official image as a parent image
FROM node:18.20-alpine as build

WORKDIR /app
COPY package.json package-lock.json ./

# Install dependencies
RUN npm install

# Get all the code needed to run the app
COPY . ./

# Build the project
RUN npm run build --prod

FROM nginx:alpine

COPY --from=build /app/dist/comete-front/browser /usr/share/nginx/html

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]