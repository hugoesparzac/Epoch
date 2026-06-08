FROM node:22-alpine AS build
WORKDIR /app

COPY src/Epoch.Client/package*.json ./
RUN npm ci

COPY src/Epoch.Client/ .

RUN npm run build

FROM nginx:alpine
WORKDIR /usr/share/nginx/html

RUN rm -rf ./*

COPY --from=build /app/dist/Epoch.Client/browser .

COPY src/Epoch.Client/nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 80
ENTRYPOINT ["nginx", "-g", "daemon off;"]
